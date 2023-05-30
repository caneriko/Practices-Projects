using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Repository.Seeds
{
    public class SignUpSeed : IEntityTypeConfiguration<Signup>
    {
        public void Configure(EntityTypeBuilder<Signup> builder)
        {
            builder.HasData(
                
                new Signup { Id=1, Email="caner@gmail.com", CreatedDate= DateTime.Now, IsActive=true },
                new Signup { Id=2, Email="caner123@gmail.com", CreatedDate= DateTime.Now, IsActive = true },
                new Signup { Id=3, Email="caner423@gmail.com", CreatedDate= DateTime.Now, IsActive = true }

                );
        }
    }
}
