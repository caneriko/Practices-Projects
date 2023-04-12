using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class seedingData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Fictional" },
                    { 20, "Romantic" },
                    { 30, "Adventure" },
                    { 40, "Technology" },
                    { 50, "Detective" },
                    { 60, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Sabahattin", "Ali" },
                    { 2, "George", "Orwell" },
                    { 3, "Sanchit", "Howdy" },
                    { 4, "Timbur", "Hood" },
                    { 5, "Adam", "Silber" },
                    { 6, "Nicole", "Wilson" },
                    { 7, "Armor", "Ramsey" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountedPrice", "ImagePath", "IsDiscounted", "Name", "Price", "PublishDate", "Stock", "WriterId" },
                values: new object[,]
                {
                    { 2, 30, "Güzel Kitap", 50m, "/images/product-item2", false, "Great Travel At Desert", 50m, new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, 3 },
                    { 3, 50, "Güzel Kitap", 38m, "/images/tab-item7", false, "Life Among The Pirates", 38m, new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, 7 },
                    { 4, 20, "Güzel Kitap", 50m, "/images/product-item4", false, "Kürk Mantolu Madonna", 50m, new DateTime(1934, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000, 1 },
                    { 10, 30, "Güzel Kitap", 40m, "/images/single-image", false, "Birds Gonna Be Happy", 40m, new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "Books");
        }
    }
}
