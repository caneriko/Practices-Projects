using AutoMapper;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Services;
using EmployeeApp.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeService _service;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _mapper = mapper;

            _service = employeeService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> All()
        {

            var employees = await _service.GetAllAsync();

            var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees.ToList());

            return View(employeeViewModels);

        }

        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);

            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            return View(employeeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var departments = await _departmentService.GetAllAsync();

            var departmentViewModels = _mapper.Map<List<DepartmentWithEmployees>>(departments.ToList());

            ViewBag.departments = new SelectList(departmentViewModels, "Id", "Name");

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Save(EmployeeViewModel newEmployee)
        {

            if (ModelState.IsValid)
            {



                await _service.AddAsync(_mapper.Map<Employee>(newEmployee));

                return RedirectToAction(nameof(All));

            }

            var departments = await _departmentService.GetAllAsync();

            var departmentViewModels = _mapper.Map<List<DepartmentWithEmployees>>(departments.ToList());

            ViewBag.departments = new SelectList(departmentViewModels, "Id", "Name");


            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var employee = await _service.GetByIdAsync(id);


            var departments = await _departmentService.GetAllAsync();

            var departmentViewModels = _mapper.Map<List<DepartmentWithEmployees>>(departments.ToList());

            ViewBag.departments = new SelectList(departmentViewModels, "Id", "Name", employee.DepartmentId);

            return View(_mapper.Map<EmployeeViewModel>(employee));
        }

        [HttpPost]

        public async Task<IActionResult> Update(EmployeeViewModel updatedModel)
        {

            if (ModelState.IsValid)
            {


                await _service.UpdateAsync(_mapper.Map<Employee>(updatedModel));

                return RedirectToAction("All");

            }

            var departments = await _departmentService.GetAllAsync();

            var departmentViewModels = _mapper.Map<List<DepartmentWithEmployees>>(departments.ToList());

            ViewBag.departments = new SelectList(departmentViewModels, "Id", "Name", updatedModel.DepartmentId);


            return View(updatedModel);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(employee);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {

            return View(await _service.GetEmployeesWithDepartment());
        }


    }
}
