using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class dalExt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9c3e3dd9-1156-4fbd-9eae-e6900368061f"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d0662080-8e84-4923-b675-06cac126445b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("44b82e4a-e5fb-414c-abdc-4fa0d3c01ffb"), new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"), " burası makale içeriği", "Admin Test", new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(886), null, null, new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), false, null, null, "Visual Stüdyo Deneme Makalesi", 15 },
                    { new Guid("af78c96d-845b-4c64-a61a-92708fb0ff22"), new Guid("760ac322-6cfc-44ee-8923-a44060701322"), " burası makale içeriği", "Admin Test", new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(874), null, null, new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760ac322-6cfc-44ee-8923-a44060701322"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 28, 20, 1, 46, 644, DateTimeKind.Local).AddTicks(1871));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("44b82e4a-e5fb-414c-abdc-4fa0d3c01ffb"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("af78c96d-845b-4c64-a61a-92708fb0ff22"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("9c3e3dd9-1156-4fbd-9eae-e6900368061f"), new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"), " burası makale içeriği", "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(7541), null, null, new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), false, null, null, "Visual Stüdyo Deneme Makalesi", 15 },
                    { new Guid("d0662080-8e84-4923-b675-06cac126445b"), new Guid("760ac322-6cfc-44ee-8923-a44060701322"), " burası makale içeriği", "Admin Test", new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(7523), null, null, new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760ac322-6cfc-44ee-8923-a44060701322"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 21, 26, 52, 71, DateTimeKind.Local).AddTicks(8812));
        }
    }
}
