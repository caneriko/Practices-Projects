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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(

                  new Image
                  {
                    Id = Guid.Parse("3435C2A1-305D-4105-9BBC-9F7327686546"),
                    FileName = "images/testimage2",
                    FileType = "jpg",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                  },
                  new Image
                  {
                      Id = Guid.Parse("C213FA88-5AD0-4B26-A1C9-9D1D793DAA3F"),
                      FileName = "images/testimage",
                      FileType = "jpg",
                      CreatedBy = "Admin Test",
                      CreatedDate = DateTime.Now,
                      IsDeleted = false
                  }

                );
        }
    }
}
