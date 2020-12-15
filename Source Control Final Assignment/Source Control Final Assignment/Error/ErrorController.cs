using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source_Control_Final_Assignment.Error
{
    public class ErrorController : Controller
    {
        // GET: Error/PageNotFound
        public ActionResult PageNotFound()
        {
            return View();
        }

        //GET: Error/AccessForbidden
        public ActionResult AccessForbidden()
        {
            return View();
        }

        public ActionResult BadRequest()
        {
            return View();
        }

    }
}