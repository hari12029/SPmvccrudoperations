using System;
using System.ComponentModel.DataAnnotations;

namespace SPmvccrudoperations.Models
{
    public class EmployeeMetadata
    {
        [Required(ErrorMessage = "EmployeeName is required")]

        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "EmployeeSalary is required")]

        public Nullable<decimal> EmployeeSalary { get; set; }

        [Required(ErrorMessage = "EmployeeCity is required")]

        public string EmployeeCity { get; set; }
    }

}