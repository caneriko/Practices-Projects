﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMvcApp.Core.Entities;

namespace MyMvcApp.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Kalem 1", Price = 100, Stock = 200, CreatedDate = DateTime.Now, },
                new Product { Id = 2, CategoryId = 1, Name = "Kalem 2", Price = 200, Stock = 100, CreatedDate = DateTime.Now, },
                new Product { Id = 3, CategoryId = 2, Name = "Kitap 1", Price = 150, Stock = 180, CreatedDate = DateTime.Now, },
                new Product { Id = 4, CategoryId = 2, Name = "Kitap 2", Price = 150, Stock = 150, CreatedDate = DateTime.Now, }

                );
        }
    }
}
