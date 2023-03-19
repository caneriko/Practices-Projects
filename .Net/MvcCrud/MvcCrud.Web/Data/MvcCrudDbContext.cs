using Microsoft.EntityFrameworkCore;
using MvcCrud.Web.Models;

namespace MvcCrud.Web.Data
{
    public class MvcCrudDbContext : DbContext 
    {
        public MvcCrudDbContext(DbContextOptions<MvcCrudDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
