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
    public class BookSeed : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                
                new Book()
                {
                    Id= 10,
                    Name="Birds Gonna Be Happy",
                    Description="Güzel Kitap",
                    Price=40,
                    Stock=1500,
                    PublishDate= new DateTime(2022,10,25),
                    ImagePath="/images/single-image",
                    WriterId=4,
                    CategoryId=30,
                    DiscountedPrice=40
                },


                new Book()
                {
                    Id = 2,
                    Name = "Great Travel At Desert",
                    Description = "Güzel Kitap",
                    Price = 50,
                    Stock = 1000,
                    PublishDate = new DateTime(2019, 10, 25),
                    ImagePath = "/images/product-item2",
                    WriterId = 3,
                    CategoryId = 30,
                    DiscountedPrice= 50
                },


                new Book()
                {
                    Id = 3,
                    Name = "Life Among The Pirates",
                    Description = "Güzel Kitap",
                    Price = 38,
                    Stock = 2000,
                    PublishDate = new DateTime(2021, 10, 25),
                    ImagePath = "/images/tab-item7",
                    WriterId =7 ,
                    CategoryId = 50,
                    DiscountedPrice = 38
                },


                new Book()
                {
                    Id = 4,
                    Name = "Kürk Mantolu Madonna",
                    Description = "Güzel Kitap",
                    Price = 50,
                    Stock = 20000,
                    PublishDate = new DateTime(1934, 10, 25),
                    ImagePath = "/images/product-item4",
                    WriterId = 1,
                    CategoryId = 20,
                    DiscountedPrice = 50
                }
                
                );
        }
    }
}
