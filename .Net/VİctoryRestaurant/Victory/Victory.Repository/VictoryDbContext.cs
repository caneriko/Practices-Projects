using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Repository
{
    public class VictoryDbContext : DbContext
    {
        public VictoryDbContext(DbContextOptions<VictoryDbContext> options) : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Signup> Signups { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
