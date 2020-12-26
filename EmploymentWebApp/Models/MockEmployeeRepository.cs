using System;
using System.Linq;
using System.Collections.Generic;

namespace EmploymentWebApp.Models
{
    // InMemory Repository
    public class MockEmployeeRepository: IEmployeeRepository
    {
        private List<Employee> _employeeList; 
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
                            {
                                new Employee() {Id=1, Name="Hussein", Email="hussein.com", Department=Dept.IT},
                                new Employee() {Id=2, Name="Hassan", Email="hassan.com", Department=Dept.IT},
                                new Employee() {Id=3, Name="Magdy", Email="magdy.com", Department=Dept.Frontend},
                                new Employee() {Id=4, Name="soliman", Email="soliman.com", Department=Dept.HR}
                            };
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(delegate (Employee emp) {return emp.Id==id;});
        }
        public int AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(delegate (Employee emp) {return emp.Id;}) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee.Id;
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if(emp != null)
            {
                emp = updatedEmployee;
            }
            return updatedEmployee;
        }
        public void DeleteEmployee(int id)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == id);
            if(emp != null)
            {
                _employeeList.Remove(emp);
            }
        }
    }
}