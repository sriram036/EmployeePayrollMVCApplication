using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Models
{
    public class LoginModel
    {
        public int EmployeeId { get; set; }

        [RegularExpression(@"^[A-Za-z]{2,}$", ErrorMessage = "{0} Starts with Alphabets")]
        public string EmployeeName { get; set; }
    }
}
