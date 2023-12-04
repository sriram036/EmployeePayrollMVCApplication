using RepositoryLayer.Interfaces;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Sessions
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeRepo employeeRepo;

        public EmployeeBusiness(IEmployeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public bool AddEmployee(Employee employee)
        {
            return employeeRepo.AddEmployee(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepo.GetAllEmployees();
        }

        public bool UpdateEmployee(Employee employee)
        {
            return employeeRepo.UpdateEmployee(employee);
        }

        public Employee GetEmployeeData(long id)
        {
            return employeeRepo.GetEmployeeData(id);
        }

        public bool DeleteEmployee(long id)
        {
            return employeeRepo.DeleteEmployee(id);
        }
    }
}
