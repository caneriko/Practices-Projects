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
    public class WriterSeed : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {

            builder.HasData(

                new Writer()
                {
                    Id = 1,
                    FirstName = "Sabahattin",
                    LastName = "Ali"
                },

                  new Writer()
                  {
                      Id = 2,
                      FirstName = "George",
                      LastName = "Orwell"
                  },

                    new Writer()
                    {
                        Id = 3,
                        FirstName = "Sanchit",
                        LastName = "Howdy"
                    },

                      new Writer()
                      {
                          Id = 4,
                          FirstName = "Timbur",
                          LastName = "Hood"
                      },

                        new Writer()
                        {
                            Id = 5,
                            FirstName = "Adam",
                            LastName = "Silber"
                        },

                          new Writer()
                          {
                              Id = 6,
                              FirstName = "Nicole",
                              LastName = "Wilson"
                          },

                            new Writer()
                            {
                                Id = 7,
                                FirstName = "Armor",
                                LastName = "Ramsey"
                            }



                );


        }
    }
}
