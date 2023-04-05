using AutoMapper;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {

            return View();
            
        }

        public async Task<IActionResult> DepartmentWithEmployees(int id)
        {

            return View(await _departmentService.DepartmentWithEmployeesAsync(id)); 

        }
    }
}
