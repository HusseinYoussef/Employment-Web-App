using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmploymentWebApp.Models
{
    public class Employee
    {
        public Employee()
        {}

        public Employee(Employee emp)
        {
            this.Name = emp.Name;
            this.Email = emp.Email;
            this.Department = emp.Department;
        }

        public int Id {get; set;}
        [Required]
        [MaxLength(50, ErrorMessage="Name cannot exceed 50 characters.")]
        public string Name {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public Dept? Department {get; set;}
        public string PhotoPath {get; set;}
    }
}