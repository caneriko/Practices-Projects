using BookSaw.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository.Configurations
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasOne(x=>x.Category).WithMany(x=>x.Articles).HasForeignKey(x=>x.CategoryId);

            builder.HasOne(x => x.User).WithMany(x => x.Articles).HasForeignKey(x => x.UserId);
        }
    }
}
