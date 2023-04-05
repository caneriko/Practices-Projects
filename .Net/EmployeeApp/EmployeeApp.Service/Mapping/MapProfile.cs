using AutoMapper;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<EmployeeUpdateViewModel, Employee>();
            CreateMap<Employee, EmployeeWithDepartment>();
            CreateMap<Department,DepartmentWithEmployees>();
        }
    }
}
