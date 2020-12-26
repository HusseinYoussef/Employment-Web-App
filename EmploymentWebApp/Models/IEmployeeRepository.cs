using System;
using System.Linq;
using System.Collections.Generic;

namespace EmploymentWebApp.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        // CRUD
        Employee GetEmployee(int id);
        int AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee updatedEmployee);
        void DeleteEmployee(int id);
    }
}