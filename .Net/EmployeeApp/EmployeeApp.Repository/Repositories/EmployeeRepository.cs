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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {


        public EmployeeRepository(EmpAppDbContext Context) :base(Context)
        {
             
        }

        public async Task<List<Employee>> EmployeesWithDepartment()
        {
            return await _context.Employees.Include(e=>e.Department).ToListAsync();
        }
    }
}
