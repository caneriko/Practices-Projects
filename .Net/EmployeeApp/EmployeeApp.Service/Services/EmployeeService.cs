using AutoMapper;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Repositories;
using EmployeeApp.Core.Services;
using EmployeeApp.Core.UnitOfWorks;
using EmployeeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeeService(IUnitOfWork unitOfWork, IGenericRepository<Employee> repository, IMapper mapper, IEmployeeRepository employeeRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeWithDepartment>> GetEmployeesWithDepartment()
        {
            var employees = await _employeeRepository.EmployeesWithDepartment();

            var employeeModels = _mapper.Map<List<EmployeeWithDepartment>>(employees);

            return employeeModels;
        }
    }
}
