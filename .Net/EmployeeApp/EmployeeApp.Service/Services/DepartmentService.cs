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
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IUnitOfWork unitOfWork, IGenericRepository<Department> repository, IMapper mapper, IDepartmentRepository departmentRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentWithEmployees> DepartmentWithEmployeesAsync(int id)
        {
            var department = await _departmentRepository.DepartmentWithEmployeesAsync(id);

            return _mapper.Map<DepartmentWithEmployees>(department);
        }
    }
}
