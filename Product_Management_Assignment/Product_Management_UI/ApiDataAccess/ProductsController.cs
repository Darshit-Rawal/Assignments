using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Product_Management_UI.Models;

namespace Product_Management_UI.ApiDataAccess
{
    public class ProductsController : ApiController
    {
        // Defining DbContext
        private ApplicationDbContext db = new ApplicationDbContext();

        // Get All Products
        // GET: api/Products
        [Route("api/Products")]
        public IHttpActionResult GetAllProducts()
        {
            return Ok(db.Products.Include("ProductCategory"));
        }

        // Get Product List
        // GET: api/ListProduct
        [Route("api/ListProduct/{sortingAs}/{page:int}/{no_of_product_per_page:int}")]
        public IHttpActionResult GetListProduct(string sortingAs, int page, int no_of_product_per_page)
        {
            IEnumerable<Product> products = db.Products.Include("ProductCategory");
            switch (sortingAs)
            {
                case "ProductCategory_sort_Ascending":
                    products = products.OrderBy(x => x.ProductCategory.ProductCategoryName);
                    break;

                case "ProductName_sort_Descending":
                    products = products.OrderByDescending(x => x.ProductName);
                    break;

                case "ProductCategory_sort_Descending":
                    products = products.OrderByDescending(x => x.ProductCategory.ProductCategoryName);
                    break;

                default:
                    products = products.OrderBy(x => x.ProductName);
                    break;
            }
            if (page == 1)
            {
                products = products.Take(no_of_product_per_page).ToList();
            }
            else
            {
                products = products.Skip(no_of_product_per_page * (page - 1)).Take(no_of_product_per_page).ToList();
            }
            return Ok(products);
        }

        // Get Product Details
        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Entry(product).Reference("ProductCategory").Load();
            return Ok(product);
        }


        // Update Product
        // PUT: api/Products/5
        //[ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ExistingProduct = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault<Product>();

            if (ExistingProduct != null)
            {
                ExistingProduct.ProductName = product.ProductName;
                ExistingProduct.PricePerUnit = product.PricePerUnit;
                ExistingProduct.LargeImagePath = product.LargeImagePath;
                ExistingProduct.LongDescription = product.LongDescription;
                ExistingProduct.ProductCategoryId = product.ProductCategoryId;
                ExistingProduct.Quantity = product.Quantity;
                ExistingProduct.ShortDescription = product.ShortDescription;
                ExistingProduct.SmallImagePath = product.SmallImagePath;

                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }


        //Add Product
        // POST: api/Products
        //[ResponseType(typeof(Product))]
        [HttpPost]
        [Route("api/Products")]
        public IHttpActionResult PostProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Ok();
        }


        //Delete Product
        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }


        // Product Count
        // GET: api/ProductCount
        public int GetProductCount()
        {
            return db.Products.Count();
        }
       
    }
}