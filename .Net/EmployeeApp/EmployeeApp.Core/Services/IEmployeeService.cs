using EmployeeApp.Core.Entities;
using EmployeeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core.Services
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<List<EmployeeWithDepartment>> GetEmployeesWithDepartment();
    }
}
