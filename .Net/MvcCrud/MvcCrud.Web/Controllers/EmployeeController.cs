using Microsoft.AspNetCore.Mvc;
using MvcCrud.Web.Data;
using MvcCrud.Web.Models;

namespace MvcCrud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MvcCrudDbContext _context;

        public EmployeeController(MvcCrudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();

            return View(employees);
        }

        [HttpGet]

        public IActionResult View(Guid id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department

                };

                return View(viewModel);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]

        public IActionResult Update(UpdateEmployeeViewModel employeeModel)
        {
            var employee = _context.Employees.Find(employeeModel.Id);

            if (employee!=null)
            {
                employee.Name = employeeModel.Name;
                employee.Salary = employeeModel.Salary;
                employee.Email = employeeModel.Email;
                employee.Department = employeeModel.Department;
                employee.DateOfBirth = employeeModel.DateOfBirth;

            } 

            _context.Employees.Update(employee);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(AddEmployeeViewModel newEmployee) 
        {
            var employee = new Employee() { 
                Name = newEmployee.Name, 
                Email = newEmployee.Email,
                Salary= newEmployee.Salary,
                DateOfBirth=newEmployee.DateOfBirth,
                Department=newEmployee.Department
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Delete(UpdateEmployeeViewModel viewModel)
        {
            var employee = _context.Employees.Find(viewModel.Id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }


    }
}
