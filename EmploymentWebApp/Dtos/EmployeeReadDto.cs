using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmploymentWebApp.Models;

namespace EmploymentWebApp.Dtos
{
    public class EmployeeReadDto
    {
        [Required]
        [MaxLength(50, ErrorMessage="Name cannot exceed 50 characters.")]
        public string Name {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public Dept? Department {get; set;}
    }
}