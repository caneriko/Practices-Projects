using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5UH1V95\\SQLEXPRESS;Initial Catalog=HotelDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Room> Rooms  { get; set; }
        public DbSet<Staff> Staff  { get; set; }
        public DbSet<Testimonial> Testimonials  { get; set; }
        public DbSet<Subscribe> Subscribes  { get; set; } 
        public DbSet<Service> Services  { get; set; } 

    }
}
