using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using NLog;
using Microsoft.AspNet.Identity;
using Product_Management_UI.Models;
using Product_Management_UI.Models.DataAccessLayer;

namespace Product_Management_UI.Controllers
{
    public class ProductCategoryController : Controller
    {
        //Initializing Logger
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        // GET: ProductCategory
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        //POST: ProductCategory
        [HttpPost]
        public ActionResult Index(ProductCategory productCategory)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22329/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<ProductCategory>("ProductCategories", productCategory);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Logger.Info("ProductCategory Created With ID: -" + productCategory.ProductCategoryId);
                    //return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}