using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DAL.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<AccountProcess> AccountProcesses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5UH1V95\\SQLEXPRESS;Initial Catalog=EasyCashDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}

