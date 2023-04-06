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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");


            builder.HasData(

                new AppUserRole
                {
                    UserId= Guid.Parse("967B3995-B6F0-4C09-97F9-C5AC3D9D7A02"),
                    RoleId=Guid.Parse("E6FC33D0-B968-454D-8900-66B1E36F2102")

                },

                new AppUserRole
                {
                    UserId = Guid.Parse("BD195F88-9F84-4BBA-81F4-727C97E4296D"),
                    RoleId = Guid.Parse("597B554D-2EC6-48C0-AFCE-C8F7A7A61B5C")
                }

                );
        }
    }
}
