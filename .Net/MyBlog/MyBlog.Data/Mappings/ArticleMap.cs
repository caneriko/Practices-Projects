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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);

            builder.HasData(
                new Article
                { Id= Guid.NewGuid(),
                              Title="Asp.Net Core Deneme Makalesi",
                              Content=" burası makale içeriği",
                              ViewCount=15,
                              CategoryId = Guid.Parse("760AC322-6CFC-44EE-8923-A44060701322"),
                              ImageId = Guid.Parse("C213FA88-5AD0-4B26-A1C9-9D1D793DAA3F"),
                              
                              CreatedBy="Admin Test",
                              CreatedDate=DateTime.Now,
                              IsDeleted=false 
                },

                 new Article
                 {
                     Id = Guid.NewGuid(),
                     Title = "Visual Stüdyo Deneme Makalesi",
                     Content = " burası makale içeriği",
                     ViewCount = 15,
                     CategoryId= Guid.Parse("2644B758-BE40-4E75-8D8B-82EC82CEDCA9"),
                     ImageId = Guid.Parse("3435C2A1-305D-4105-9BBC-9F7327686546"),
                     CreatedBy = "Admin Test",
                     CreatedDate = DateTime.Now,
                     IsDeleted = false
                 }

                );

        }
    }
}
