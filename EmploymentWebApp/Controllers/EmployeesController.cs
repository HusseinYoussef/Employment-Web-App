using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmploymentWebApp.Models;
using AutoMapper;
using EmploymentWebApp.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Serialization;

namespace EmploymentWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            if(employees.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}", Name="GetEmployee")]
        public ActionResult<EmployeeReadDto> GetEmployee(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeReadDto>(employee));
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            _employeeRepository.AddEmployee(employee);

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employee);
            return CreatedAtRoute("GetEmployee", new {id=employee.Id}, employeeReadDto);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeCreateDto employeeCreateDto)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeCreateDto, employee);
            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }
    }
}