using EMS.BE;
using EMS.BLL.Classes;
using EMS.BLL.Interfaces;
using EMS.MVC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.MVC.Controllers
{
    [WriteResponseHeader]
    public class EmpolyeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        public EmpolyeeController(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }
        [HttpGet]
        [Route("Employee")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = (int)0.5)]
        public IActionResult Index()
        {
            var emps = _employeeManager.GetAll();
            return View(emps);
            //return View(_employeeManager.GetAll());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            IEnumerable<Department> listDept = new List<Department>(_departmentManager.GetAll());
            IEnumerable<Employee> listManager = new List<Employee>(_employeeManager.GetManagers());
            ViewBag.Departments = listDept;
            ViewBag.Managers = listManager;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Employee employe)
        {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            employe.departmentId = Guid.Parse(dict["DeptId"]);
            var response = _employeeManager.Add(employe);
            if (response)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            return View(_employeeManager.Get(id));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(Guid id)
        {
            Employee entity = _employeeManager.Get(id);
            IEnumerable<Department> listDept = new List<Department>(_departmentManager.GetAll());
            IEnumerable<Employee> listManager = new List<Employee>(_employeeManager.GetManagers());
            ViewBag.Departments = listDept;
            ViewBag.Managers = listManager;
            return View("Create", entity);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Employee employee)
        {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            employee.departmentId = Guid.Parse(dict["DeptId"]);
            var result = _employeeManager.Update(employee);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var result = _employeeManager.Delete(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
