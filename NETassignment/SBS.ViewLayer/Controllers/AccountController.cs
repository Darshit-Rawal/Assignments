using SBS.BusinessEntity;
using SBS.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace SBS.ViewLayer.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Register
        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        // GET: Account/Login
        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10020/Account/Register");

                var postTask = client.PostAsJsonAsync<Customer>("Register", customer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("/Register");
                }
            }
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10020/token");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.DefaultRequestHeaders.Accept.Clear();

                password = Convert.ToBase64String(PassowrdEncrypt.Encrypt(password));

                var responseMessage = client.PostAsJsonAsync("token", "grant_type=password&username=" + email + "&password=" + password);
                responseMessage.Wait();

                var result = responseMessage.Result;
                Debug.WriteLine(result.Content);

            }
            return RedirectToAction("Index");
        }

    }
}