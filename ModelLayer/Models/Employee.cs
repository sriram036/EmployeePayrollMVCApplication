using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeProfile { get; set; }

        public bool EmployeeGender { get; set; }

        public string EmployeeDepartment { get; set; }

        public long EmployeeSalary { get; set; }

        public DateTime EmployeeStartDate { get; set; }

        public string EmployeeNotes { get; set; }
    }
}
