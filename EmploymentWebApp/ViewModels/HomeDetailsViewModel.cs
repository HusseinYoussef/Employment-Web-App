using EmploymentWebApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EmploymentWebApp.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee {get; set;}
        public string PageTitle {get; set;}
    }
}