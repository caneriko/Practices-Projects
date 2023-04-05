using EmployeeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Repository
{
    public class EmpAppDbContext : DbContext
    {
        public EmpAppDbContext(DbContextOptions<EmpAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; } 

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
