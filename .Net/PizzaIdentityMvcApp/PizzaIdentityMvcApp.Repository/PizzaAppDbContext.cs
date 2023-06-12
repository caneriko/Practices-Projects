using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaIdentityMvcApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Repository
{
    public class PizzaAppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public PizzaAppDbContext(DbContextOptions<PizzaAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pizza> MyProperty { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<AppUser>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        //    });
        //}
    }
}

