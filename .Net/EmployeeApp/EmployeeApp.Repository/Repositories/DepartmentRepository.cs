using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmpAppDbContext Context) : base(Context)
        {

        }
        public async Task<Department> DepartmentWithEmployeesAsync(int id)
        {
            return await _context.Departments.Include(x => x.Employees).Where(x => x.Id == id).SingleOrDefaultAsync(); 
        }
    }
}
