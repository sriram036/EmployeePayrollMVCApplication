using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] Employee employee)
        {
            try
            {
                employeeBusiness.AddEmployee(employee);
                return RedirectToAction("GetEmployees");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                IEnumerable<Employee> Employees = employeeBusiness.GetAllEmployees();
                
                TempData["EmployeeIds"] = Employees.ToList();
                //return View(Employees);
                return RedirectToAction("Index", "Home", Employees);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetEmployeeData()
        {
            try
            {
                long id = long.Parse(HttpContext.Session.GetString("EmployeeId"));
                
                return View(employeeBusiness.GetEmployeeData(id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult UpdateEmployee(long id)
        {
            try
            {
                Employee employee = employeeBusiness.GetEmployeeData(id);
                return View(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployee([Bind] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeBusiness.UpdateEmployee(employee);
                    return RedirectToAction("GetEmployees");
                }
                return View(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult DeleteEmployee(long id)
        {
            try
            {
                Employee employee = employeeBusiness.GetEmployeeData(id);
                return View(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult Delete(long id)
        {
            try
            {
                employeeBusiness.DeleteEmployee(id);
                return RedirectToAction("GetEmployees");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Login([Bind] LoginModel Login)
        {
            try
            {
                long Id = employeeBusiness.Login(Login);
                //string url = "GetEmployeeData/" + employee.EmployeeId;
                HttpContext.Session.SetString("EmployeeId", Id.ToString());
                if(Id > 0)
                {
                    return RedirectToAction("GetEmployeeData");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
