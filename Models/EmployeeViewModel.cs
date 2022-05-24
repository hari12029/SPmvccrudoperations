using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPmvccrudoperations.Models
{
    public class EmployeeViewModel
    {
        public int Employeeid { get; set; }

        public string EmployeeName { get; set; }

        public Nullable<decimal> EmployeeSalary { get; set; }

        public string EmployeeCity { get; set; }
    }
}