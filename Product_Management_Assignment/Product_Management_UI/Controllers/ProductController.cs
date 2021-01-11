using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NLog;
using Product_Management_UI.Models;
using Product_Management_UI.Models.DataAccessLayer;
using Product_Management_UI.GlobalParameters;
using System.Net.Http;

namespace Product_Management_UI.Controllers
{
    public class ProductController : Controller
    {   
        //Initializing Logger
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        //Globla Params Access Object
        ProductsParams productsParams = new ProductsParams();

        //Data Access Object
        ProductDataAccess productDataAccess = new ProductDataAccess(); 

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.GetUserId() == null)
            {
                return Redirect("~/Account/Login?query="+"NotLogin");
            }
            IEnumerable<ProductCategory> productCategories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductCategories");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ProductCategory>>();
                    readTask.Wait();

                    productCategories = readTask.Result;
                }
                else //web api sent error response 
                {

                    productCategories = Enumerable.Empty<ProductCategory>();
                }
            }
            SelectList ListCategories = new SelectList(productCategories.Select(x => x.ProductCategoryName));
            ViewBag.categories = ListCategories;
            return View();
        }
        
        // POST: Product
        [HttpPost]
        public ActionResult Index(Product product)
        {
            IEnumerable<ProductCategory> productCategories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductCategories");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ProductCategory>>();
                    readTask.Wait();

                    productCategories = readTask.Result;
                }
                else //web api sent error response 
                {
                    productCategories = Enumerable.Empty<ProductCategory>();
                }
            }
            //IEnumerable<ProductCategory> productCategories = categoryDataAccess.GetAllProductCategories();
            var x = Request.Params["ProductCategoryId"];
            product.ProductCategoryId = productCategories.Where(y => y.ProductCategoryName == x).First().ProductCategoryId;
            //product.CreatedBy = User.Identity.GetUserId();
            List<string> imagePath = new List<string>();
            var Uploaded_files = Request.Files;
            var SmallImageFile = Request.Files["small_image"];
            var LargeImageFile = Request.Files["large_image"];
            if (Request.Files["small_image"] != null && Request.Files["large_image"] != null)
            {
                for (int i = 0; i < Uploaded_files.Count; i++)
                {
                    IDictionary<int, string> dict = SaveImage(Uploaded_files[i]);
                    foreach (KeyValuePair<int, string> item in dict)
                    {
                        if (item.Key == 0)
                        {
                            //ModelState.AddModelError("uploadError", item.Value);
                            ViewBag.error = item.Value;
                            SelectList ListCategories = new SelectList(productCategories.Select(z => z.ProductCategoryName));
                            ViewBag.categories = ListCategories;
                            return Redirect("/Product/Index?error=" + item.Value);
                        }
                        imagePath.Add(item.Value);
                    }
                }
            }

            try
            {
                product.SmallImagePath = imagePath[0];
                product.LargeImagePath = imagePath[1];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22329/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Product>("Products", product);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Logger.Info("Product Created With ID: -" + product.ProductId);
                        //return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                TempData["error"] = true;
                Logger.Error("Error Occured While Creating Product: -" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        //Get: Product/ProductDetails
        [HttpGet]
        public ActionResult ProductDetails()
        {
            int ProductId = int.Parse(Request.QueryString["ProductId"]);
            Product product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");

                var responseTask = client.GetAsync("Products/"+ProductId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Product>();
                    readTask.Wait();

                    product = readTask.Result;
                }
                else
                {
                    product = new Product();
                }
            }
            ViewBag.product = product;
            return View();
        }

        //Get: Product/ProductEdit
        [HttpGet]
        public ActionResult ProductEdit()
        {
            int ProductId = int.Parse(Request.QueryString["ProductId"]);
            Product product = null;
            IEnumerable<ProductCategory> productCategories = null;
            string editProductName = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");

                var responseTask = client.GetAsync("Products/" + ProductId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Product>();
                    readTask.Wait();

                    product = readTask.Result;
                }
                else
                {
                    product = new Product();
                }

                var responseTask1 = client.GetAsync("ProductCategories");
                responseTask1.Wait();

                var result1 = responseTask1.Result;
                if (result1.IsSuccessStatusCode)
                {
                    var readTask1 = result1.Content.ReadAsAsync<IEnumerable<ProductCategory>>();
                    readTask1.Wait();

                    productCategories = readTask1.Result;
                }
                else
                {
                    productCategories = Enumerable.Empty<ProductCategory>();
                }

                var responseTask2 = client.GetAsync("ProductCategories/"+product.ProductId);
                responseTask2.Wait();

                var result2 = responseTask2.Result;
                if (result2.IsSuccessStatusCode)
                {
                    var readTask2 = result2.Content.ReadAsAsync<ProductCategory>();
                    readTask2.Wait();

                    ProductCategory category = readTask2.Result;
                    editProductName = category.ProductCategoryName;
                }
                else
                {
                    editProductName = null;
                }
            }
            //Server.TransferRequest("~/Error/Page", true);
            if (product.CreatedBy != User.Identity.GetUserId())
            {
                Server.TransferRequest("~/Error/AccessForbidden", true);
            }
            else
            {
                //productCategories = categoryDataAccess.GetAllProductCategories();
                SelectList ListCategories = new SelectList(productCategories.Select(x => x.ProductCategoryName));
                ViewBag.categories = ListCategories;
                ViewBag.editProduct = product;
                ViewBag.editProductCategory = product.ProductCategory.ProductCategoryName;
            }
            return View("Index");
        }
        
        //Post: Product/ProductEdit
        [HttpPost]
        public ActionResult ProductEdit(Product newProduct)
        {
            //IEnumerable<ProductCategory> productCategories = categoryDataAccess.GetAllProductCategories();
            IEnumerable<ProductCategory> productCategories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");

                var responseTask = client.GetAsync("ProductCategories");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ProductCategory>>();
                    readTask.Wait();

                    productCategories = readTask.Result;
                }
                else
                {
                    productCategories = Enumerable.Empty<ProductCategory>();
                }
            }
            var x = Request.Params["ProductCategoryId"];
            newProduct.ProductId = int.Parse(Request.Params["EditProductId"]);
            newProduct.ProductCategoryId = productCategories.Where(y => y.ProductCategoryName == x).First().ProductCategoryId;

            //Update Product
            Product oldProduct = productDataAccess.GetProductByIdWithCategory(newProduct.ProductId);
            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.PricePerUnit = newProduct.PricePerUnit;
            oldProduct.Quantity = newProduct.Quantity;
            oldProduct.ProductCategoryId = newProduct.ProductCategoryId;
            oldProduct.ShortDescription = newProduct.ShortDescription;
            oldProduct.LongDescription = newProduct.LongDescription;
            oldProduct.CreatedAt = DateTime.Now;

            var SmallImageFile = Request.Files["small_image"];
            var LargeImageFile = Request.Files["large_image"];
            if (SmallImageFile.ContentLength > 0)
            {
                IDictionary<int, string> dict = SaveImage(SmallImageFile);
                foreach (KeyValuePair<int, string> item in dict)
                {
                    if (item.Key == 0)
                    {
                        SelectList ListCategories = new SelectList(productCategories.Select(z => z.ProductCategoryName));
                        return Redirect("/Product/Index?error=" + item.Value + "&productId=" + oldProduct.ProductId);
                    }
                    try
                    {
                        DeleteImage(oldProduct.SmallImagePath);
                        oldProduct.SmallImagePath = item.Value;
                    }
                    catch (Exception e)
                    {
                        TempData["error"] = true;
                        Logger.Error("Small Image File Deletion Failed!! with Product ID: -" + oldProduct.ProductId + " With Message: -" + e.Message);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            if (LargeImageFile.ContentLength > 0)
            {
                IDictionary<int, string> dict = SaveImage(LargeImageFile);
                foreach (KeyValuePair<int, string> item in dict)
                {
                    if (item.Key == 0)
                    {
                        SelectList ListCategories = new SelectList(productCategories.Select(z => z.ProductCategoryName));
                        ViewBag.categories = ListCategories;
                        return Redirect("/Product/Index?error=" + item.Value + "&productId=" + oldProduct.ProductId);
                    }
                    try
                    {
                        DeleteImage(oldProduct.LargeImagePath);
                        oldProduct.LargeImagePath = item.Value;
                    }
                    catch (Exception e)
                    {
                        TempData["error"] = true;
                        Logger.Error("Large Image File Deletion Failed!! with Product ID: -" + oldProduct.ProductId + " With Message: -" + e.Message);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            try
            {
                productDataAccess.Save();
                TempData["EditSuccess"] = true;
                Logger.Info("Edit Product Successful with ID: -" + oldProduct.ProductId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                TempData["error"] = true;
                Logger.Error("Edit Product Failed with ID: -" + oldProduct.ProductId + "\n" + "Error Message: -" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        //POST: Product/ProductDelete
        [HttpGet]
        public ActionResult ProductDelete()
        {   
            int productId = int.Parse(Request.QueryString["ProductId"]);
            try
            {
                //Product p = productDataAccess.GetProductByIdWithCategory(productId);
                Product p = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22329/api/");

                    var responseTask = client.GetAsync("Products/" + productId);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Product>();
                        readTask.Wait();

                        p = readTask.Result;
                    }
                    else
                    {
                        p = new Product();
                    }
                }
                if (p.CreatedBy != User.Identity.GetUserId())
                {
                    Server.TransferRequest("~/Error/AccessForbidden", true);
                }
                try
                {
                    DeleteImage(p.SmallImagePath);
                    DeleteImage(p.LargeImagePath);
                }
                catch (Exception e)
                {
                    TempData["error"] = true;
                    Logger.Error("Small Image OR large File Deletion Failed!! with Product ID: -" + p.ProductId + " With Message: -" + e.Message);
                    return RedirectToAction("Index", "Home");
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22329/api/");

                    var deleteTask = client.DeleteAsync("Products/" + productId);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["DeleteSuccess"] = true;
                        Logger.Info("Delete Product Successful with ID: -" + productId);
                        //return RedirectToAction("Index");
                    }
                }
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                TempData["error"] = true;
                Logger.Error("Delete Product Successful with ID: -" + productId + "\n" + "Error Message: -" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Product/DeleteMultipleProducts
        [HttpGet]
        public ActionResult DeleteMultipleProducts()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Product> products = null; 
            if (userId == null)
            {
                return Redirect("~/Account/Login?query=" + "NotLogin");
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");

                // HTTP GET
                var responseTask = client.GetAsync("Products");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var ReadTask = result.Content.ReadAsAsync<IEnumerable<Product>>();
                    products = ReadTask.Result;
                }
            }
            products = products.Where(x => x.CreatedBy == userId);
            ViewBag.products = products;
            return View();
        }
        
        // POST: Product/DeleteMultipleProducts
        [HttpPost]
        public ActionResult DeleteMultipleProducts(Product product)
        {
            Debug.WriteLine(Request.Params["product_ids"]);
            string[] ids = Request.Params["product_ids"].Split(',');
            ids = ids.Take(ids.Length - 1).ToArray();
            string string_of_ids = "";
            try
            {
                foreach (var id_string in ids)
                {
                    int id = int.Parse(id_string);

                    Product p = null;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:22329/api/");

                        var responseTask = client.GetAsync("Products/" + id);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<Product>();
                            readTask.Wait();

                            p = readTask.Result;
                        }
                        else
                        {
                            p = new Product();
                        }



                        var deleteTask = client.DeleteAsync("Products/" + p.ProductId);
                        deleteTask.Wait();

                        var result1 = deleteTask.Result;
                        if (result1.IsSuccessStatusCode)
                        {
                            //return RedirectToAction("Index");
                        }

                    }

                    //Product p = productDataAccess.GetProductByIdWithCategory(id);
                    //productDataAccess.DeleteProduct(productDataAccess.GetProductById(id));
                    //productDataAccess.DeleteProduct(p);
                    string_of_ids = id_string + ",";
                    try
                    {
                        DeleteImage(p.SmallImagePath);
                        DeleteImage(p.LargeImagePath);
                    }
                    catch (Exception e)
                    {
                        TempData["error"] = true;
                        Logger.Error("Small Image OR large File Deletion Failed!! with Product ID: -" + p.ProductId + " With Message: -"+ e.Message);
                        return RedirectToAction("Index", "Home");
                    }
                }
                //productDataAccess.Save();
                Logger.Info("Delete Products Successful with IDs: -"+ string_of_ids);
                TempData["DeleteSuccess"] = true;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                TempData["error"] = true;
                Logger.Info("Multiple Deleting Failed!! with Message: -" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        
        //Store Image in Folder
        public IDictionary<int, string> SaveImage(HttpPostedFileBase image)
        {
            string message = ""; // message is some user friendly message for error and file path for successful operation
            int code = 0;   // code = 0 Represents Some Error and code = 1 Represents Success
            string path = "";
            string path_store = "";
            IDictionary<int, string> d = new Dictionary<int, string>();
            if (image.ContentLength == 0)
            {
                message = "Empty File Found!!";
                code = 0;
            }
            else
            {
                if (image.ContentLength < 100)
                {
                    message = "File size is too small";
                    code = 0;
                }
                else
                {
                    string extension = Path.GetExtension(image.FileName).ToLower();
                    if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                    {
                        message = "Unsupported Extension, Supported Extension Are: .png, .jpg, .jpeg";
                        code = 0;
                    }
                    else
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        path = Path.Combine(Server.MapPath("~/UserFiles"), fileName);
                        path_store = "/UserFiles/" + fileName;
                        try
                        {
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                            image.SaveAs(path);
                            message = path_store;
                            code = 1;
                        }
                        catch (Exception)
                        {
                            message = "Some Server Error Occured!! Please Retry After Sometime!!";
                            code = 0;
                        }
                    }
                }
            }
            d.Add(new KeyValuePair<int, string>(code, message));
            return d;
        }

        //Delete Image from Folder
        public void DeleteImage(string ImagePath)
        {
            string ImageName = ImagePath.Split('/')[2];
            var filePath = Server.MapPath("~/UserFiles/" + ImageName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}