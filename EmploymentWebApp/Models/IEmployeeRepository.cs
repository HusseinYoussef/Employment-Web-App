using System;
using System.Linq;
using System.Collections.Generic;

namespace EmploymentWebApp.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
    }
}