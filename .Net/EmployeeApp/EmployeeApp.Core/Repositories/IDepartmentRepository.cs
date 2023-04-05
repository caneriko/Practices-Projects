using EmployeeApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department> DepartmentWithEmployeesAsync(int id);
    }
}
