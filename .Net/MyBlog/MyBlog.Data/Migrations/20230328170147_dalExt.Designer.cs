﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Data.Context;

#nullable disable

namespace MyBlog.Data.Migrations
{
    [DbContext(typeof(MyBlogDbContext))]
    [Migration("20230328170147_dalExt")]
    partial class dalExt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBlog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af78c96d-845b-4c64-a61a-92708fb0ff22"),
                            CategoryId = new Guid("760ac322-6cfc-44ee-8923-a44060701322"),
                            Content = " burası makale içeriği",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(874),
                            ImageId = new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"),
                            IsDeleted = false,
                            Title = "Asp.Net Core Deneme Makalesi",
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("44b82e4a-e5fb-414c-abdc-4fa0d3c01ffb"),
                            CategoryId = new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"),
                            Content = " burası makale içeriği",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(886),
                            ImageId = new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"),
                            IsDeleted = false,
                            Title = "Visual Stüdyo Deneme Makalesi",
                            ViewCount = 15
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("760ac322-6cfc-44ee-8923-a44060701322"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1514),
                            IsDeleted = false,
                            Name = "ASP.Net Core"
                        },
                        new
                        {
                            Id = new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1522),
                            IsDeleted = false,
                            Name = "Visual Studio"
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1863),
                            FileName = "images/testimage2",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1871),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Article", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}