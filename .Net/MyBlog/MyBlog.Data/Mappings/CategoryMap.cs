using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(

              new Category
              {
                  Id = Guid.Parse("760AC322-6CFC-44EE-8923-A44060701322"),
                  Name = "ASP.Net Core",
                  CreatedBy = "Admin Test",
                  CreatedDate = DateTime.Now,
                  IsDeleted = false,
              },
              new Category
              {
                  Id = Guid.Parse("2644B758-BE40-4E75-8D8B-82EC82CEDCA9"),
                  Name = "Visual Studio",
                  CreatedBy = "Admin Test",
                  CreatedDate = DateTime.Now,
                  IsDeleted = false,
              }



                );





        }
    }
}
