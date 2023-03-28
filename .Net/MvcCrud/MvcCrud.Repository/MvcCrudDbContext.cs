using Microsoft.EntityFrameworkCore;
using MvcCrud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrud.Repository
{
    public class MvcCrudDbContext : DbContext
    {
        public MvcCrudDbContext(DbContextOptions<MvcCrudDbContext> options) : base(options) 
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
