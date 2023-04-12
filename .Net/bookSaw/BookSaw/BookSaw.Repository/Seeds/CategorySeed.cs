using BookSaw.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(

                new Category()
                {
                    Id = 10,
                    Name = "Fictional"

                },

                 new Category()
                 {
                     Id = 20,
                     Name = "Romantic"

                 },


                  new Category()
                  {
                      Id = 30,
                      Name = "Adventure"

                  },


                   new Category()
                   {
                       Id = 40,
                       Name = "Technology"

                   },

                     new Category()
                     {
                         Id = 50,
                         Name = "Detective"

                     },

                      new Category()
                      {
                          Id = 60,
                          Name = "Kids"

                      }


                );



        }
    }
}
