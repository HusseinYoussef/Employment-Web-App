using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmploymentWebApp.Models;
using EmploymentWebApp.ViewModels;

namespace EmploymentWebApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee changedEmployee)
        {
            if(ModelState.IsValid)
            {
                // Employee oldEmployee = _employeeRepository.GetEmployee(changedEmployee.Id);
                _employeeRepository.UpdateEmployee(changedEmployee);
                return RedirectToAction("details", new {id=changedEmployee.Id});
            }
            return View(changedEmployee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                int employeeId = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("details", new {id=employeeId});
            }
            return View();
        }

        public RedirectToActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("index");
        }
    }
}