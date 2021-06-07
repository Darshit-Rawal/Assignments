using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Models;

namespace TODOList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IOptions<EnvSettings> _conf;
        Provider provider = new Provider();

        public HomeController(ILogger<HomeController> logger, IOptions<EnvSettings> conf)
        {
            _conf = conf;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = provider.GetLists();
            ViewBag.Status = TempData["Status"];
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateList(string ListName)
        {
            var EnvironmentCount = _conf.Value.ItemCount;
            if (provider.GetListCount() < EnvironmentCount)
            {
                provider.CreateList(ListName);
                TempData["Status"] = true;
            }
            else
            {
                TempData["Status"] = false;
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateStatus()
        {
            var listItem = Request.Path.Value.Split("/");
            var items = listItem[3].Split('-');
            provider.UpdateListItemFlag(int.Parse(items[0]), int.Parse(items[1]));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateItemInList(string ItemName)
        {
            var listId = int.Parse(Request.Form["list"]);
            provider.AddItemToList(listId, ItemName);
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult PartialCreateList()
        {
            return PartialView("CreateListPartial");
        }

        public PartialViewResult PartialAddItemToList()
        {
            var model = provider.GetLists();
            return PartialView("PartialAddItemToList", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
