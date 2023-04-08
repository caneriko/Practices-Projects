using BookSaw.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository
{
    public class BookSawDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public BookSawDbContext(DbContextOptions<BookSawDbContext> options)  : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Quotation> Quotations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            base.OnConfiguring(optionsBuilder);
        }


    }
}
