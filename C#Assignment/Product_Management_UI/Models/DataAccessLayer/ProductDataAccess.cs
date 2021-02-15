using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity.SqlServer;

namespace Product_Management_UI.Models.DataAccessLayer
{
    public class ProductDataAccess
    {
        private ApplicationDbContext _productDbContext = new ApplicationDbContext();
        
        #region SearchProduct
        public IEnumerable<Product> GetProductsByName(string name, string search_on, int page, int no_of_product_per_page, out int product_count)
        {
            IEnumerable<Product> products;
            if (search_on.Equals("ProductName"))
            {
                //products = _productDbContext.Products
                //    .Include("ProductCategory")
                //    .Where(x => SqlFunctions.PatIndex("%" + name + "%", x.ProductName) > 0);
                products = _productDbContext.Products
                    .Include("ProductCategory")
                    .Where(x => x.ProductName.Contains(name));

                //products = GetAllProductsWithCategory(sorting_as).Where(x => SqlFunctions.PatIndex("%" + name + "%", x.ProductName) > 0);
            }
            else
            {
                //products = _productDbContext.Products
                //    .Include("ProductCategory")
                //    .Where(x => SqlFunctions.PatIndex("%" + name + "%", x.ProductCategory.ProductCategoryName) > 0);

                products = _productDbContext.Products
                    .Include("ProductCategory")
                    .Where(x => x.ProductCategory.ProductCategoryName.Contains(name));
                //products = GetAllProductsWithCategory(sorting_as).Where(x => SqlFunctions.PatIndex("%" + name + "%", x.ProductCategory.ProductCategoryName) > 0);
            }
            product_count = products.Count();
            products = products.Skip(no_of_product_per_page * (page - 1)).Take(no_of_product_per_page).ToList();
            return products;
        }
        #endregion
        
        #region GetProduct
        public Product GetProductByIdWithCategory(int id)
        {
            Product product;
            product = _productDbContext.Products.Find(id);
            _productDbContext.Entry(product).Reference("ProductCategory").Load();
            return product;
        }
        #endregion
        
        #region Save
        public void Save()
        {
            _productDbContext.SaveChanges();
        } 
        #endregion

    }
}