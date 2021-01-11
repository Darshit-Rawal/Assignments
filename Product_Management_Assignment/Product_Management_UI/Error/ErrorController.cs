using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Management_UI.Error
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
    }
}