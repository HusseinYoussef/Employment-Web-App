using System;
using System.Collections.Generic;
using AutoMapper;
using EmploymentWebApp.Dtos;
using EmploymentWebApp.Models;

namespace EmploymentWebApp.Profiles
{
    public class EmployeesProfile: Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Employee, EmployeeCreateDto>();
        }
    }
}