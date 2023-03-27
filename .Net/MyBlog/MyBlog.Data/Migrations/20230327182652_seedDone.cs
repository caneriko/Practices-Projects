using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"), "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8313), null, null, false, null, null, "Visual Studio" },
                    { new Guid("760ac322-6cfc-44ee-8923-a44060701322"), "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8304), null, null, false, null, null, "ASP.Net Core" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8685), null, null, "images/testimage2", "jpg", false, null, null },
                    { new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8812), null, null, "images/testimage", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("9c3e3dd9-1156-4fbd-9eae-e6900368061f"), new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"), " burası makale içeriği", "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(7541), null, null, new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), false, null, null, "Visual Stüdyo Deneme Makalesi", 15 },
                    { new Guid("d0662080-8e84-4923-b675-06cac126445b"), new Guid("760ac322-6cfc-44ee-8923-a44060701322"), " burası makale içeriği", "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(7523), null, null, new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9c3e3dd9-1156-4fbd-9eae-e6900368061f"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d0662080-8e84-4923-b675-06cac126445b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760ac322-6cfc-44ee-8923-a44060701322"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"));
        }
    }
}
