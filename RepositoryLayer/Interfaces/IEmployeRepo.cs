using ModelLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeRepo
    {
        bool AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeData(long id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(long id);
    }
}