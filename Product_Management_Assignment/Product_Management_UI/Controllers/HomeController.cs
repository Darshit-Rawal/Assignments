using Product_Management_UI.Models;
using Product_Management_UI.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product_Management_UI.GlobalParameters;
using System.Net.Http;

namespace Product_Management_UI.Controllers
{
    public class HomeController : Controller
    {
        ProductDataAccess productDataAccess = new ProductDataAccess();

        public ActionResult Index()
        {
            int page = 1;
            IEnumerable<Product> products;
            ProductsParams productsParams = new ProductsParams();
            var search_product = Request.Params["product"];
            if (search_product == "")
            {
                search_product = null;
            }

            var search_on = Request.Params["searchOn"];
            var sorting_on = Request.Params["sortOn"];
            var sorting_order = Request.Params["sortOrder"];
            var sorting_as = sorting_on + "_" + sorting_order;
            var error = TempData["error"];
            int product_count = 0;
            int product_count_out = 0;
            if (Request.Params["page"] != null)
            {
                page = int.Parse(Request.Params["page"]);
            }
            else
            {
                page = 1;
            }
            if (search_product != null)
            {
                products = productDataAccess.GetProductsByName(search_product, search_on, page, productsParams.getProduct_per_page(), out product_count_out);
                product_count = product_count_out;
                //product_count = products.Count();
            }   
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22329/api/");

                    var responseTask = client.GetAsync("ListProduct/"+sorting_as + "/" + page + "/" + productsParams.getProduct_per_page());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IEnumerable<Product>>();
                        readTask.Wait();
                        products = readTask.Result;
                    }
                    else
                    {
                        products = Enumerable.Empty<Product>();
                    }


                    var responseTask1 = client.GetAsync("ProductCount");
                    responseTask1.Wait();

                    var result1 = responseTask1.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        var readTask1 = result1.Content.ReadAsAsync<int>();
                        readTask1.Wait();
                        product_count = readTask1.Result;
                    }
                    else
                    {
                        product_count = new int();
                    }
                }
            }
            ViewBag.products = products;
            ViewBag.error = error;
            //Debug.WriteLine(TempData["DeleteSuccess"]);
            ViewBag.deletion_success = TempData["DeleteSuccess"];
            ViewBag.editing_success = TempData["EditSuccess"];

            //Sorting Params for Pagination
            ViewBag.sortOrder = sorting_order;
            ViewBag.sortOn = sorting_on;

            //Searching Params for Pagination
            ViewBag.product = search_product;
            ViewBag.searchOn = search_on;

            //Last Page Calculation
            ViewBag.lastPage = Math.Ceiling((decimal)product_count / productsParams.getProduct_per_page());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}