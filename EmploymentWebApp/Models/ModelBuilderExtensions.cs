using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmploymentWebApp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Hussein",
                    Email = "Hussein@gmail.com",
                    Department = Dept.IT
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Hassan",
                    Email = "Hassan@gmail.com",
                    Department = Dept.IT
                }
            );
        }
    }
}