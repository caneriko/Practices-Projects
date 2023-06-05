using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Repository.Configurations
{
    public class SignUpConfiguration : IEntityTypeConfiguration<Signup>
    {
        public void Configure(EntityTypeBuilder<Signup> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(64);
            builder.Property(x=>x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
