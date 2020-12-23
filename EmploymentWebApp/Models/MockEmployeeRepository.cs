using System;
using System.Linq;
using System.Collections.Generic;

namespace EmploymentWebApp.Models
{
    public class MockEmployeeRepository: IEmployeeRepository
    {
        private List<Employee> _employeeList; 
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
                            {
                                new Employee() {Id=1, Name="Hussein", Email="hussein.com", Department="IT"},
                                new Employee() {Id=2, Name="Hassan", Email="hassan.com", Department="IT"},
                                new Employee() {Id=3, Name="Magdy", Email="magdy.com", Department="Frontend"},
                                new Employee() {Id=4, Name="soliman", Email="soliman.com", Department="computer"}
                            };
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(delegate (Employee emp) {return emp.Id==id;});
        }
    }
}