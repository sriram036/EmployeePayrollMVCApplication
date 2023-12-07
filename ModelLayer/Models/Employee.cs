using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        [RegularExpression(@"^[A-Za-z]{2,}$", ErrorMessage = "{0} Starts with Alphabets")]
        public string EmployeeName { get; set; }

        public string EmployeeProfile { get; set; }

        public string EmployeeGender { get; set; }

        public string EmployeeDepartment { get; set; }

        [RegularExpression(@"^[3-9][0-9]{4,}|[1-2][0-9]{5,}$", ErrorMessage = "{0} should be more than 30000")]
        public long EmployeeSalary { get; set; }

        public DateTime EmployeeStartDate { get; set; }

        public string EmployeeNotes { get; set; }

        
    }
}
