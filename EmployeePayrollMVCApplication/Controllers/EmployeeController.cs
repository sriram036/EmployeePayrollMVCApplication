using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using System.Collections.Generic;

namespace EmployeePayrollMVCApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBusiness employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            this.employeeBusiness = employeeBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBusiness.AddEmployee(employee);
                return RedirectToAction("GetEmployees");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return View(employeeBusiness.GetAllEmployees());
        }

        [HttpGet]
        public IActionResult GetEmployeeData(long id)
        {
            return View(employeeBusiness.GetEmployeeData(id));
        }

        [HttpGet]
        public IActionResult UpdateEmployee(long id)
        {
            Employee employee = employeeBusiness.GetEmployeeData(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBusiness.UpdateEmployee(employee);
                return RedirectToAction("GetEmployees");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(long id)
        {
            Employee employee = employeeBusiness.GetEmployeeData(id);
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult Delete(long id)
        {
            employeeBusiness.DeleteEmployee(id);
            return RedirectToAction("GetEmployees");
        }
    }
}
