using ModelLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBusiness
    {
        bool AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeData(long id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(long id);
        long Login(LoginModel loginModel);
    }
}