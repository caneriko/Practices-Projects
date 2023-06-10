using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class newuserprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "02c99b03-e697-4a33-bce8-4280abbb3dea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "962b166d-4fe4-41d9-89ee-02961cdd4ba2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "68d76bc4-23fe-4dae-ab08-675d6983b610");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e12c7d5d-0c67-4083-933d-4a4a2a06c134", "CANERIKO", "AQAAAAEAACcQAAAAELaiKWwhZ3HC5exujmdMQSGK+dGQUU24PWcpkRacmPDsRq+J5ztY7RM1bK4Z8Iic9w==", "1eba88fd-df20-4235-a95d-d47e840c8b34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64fcece7-5a5d-497e-8e81-04cb872bf328", "BAFE", "AQAAAAEAACcQAAAAEC58IcJH/VaxNapIidQWEw1ffdYRH/uzgvgt7mXuc886a8xaSOodd8I2RuA+FSw8OA==", "28a111ea-8ebb-4d58-baf6-19d13acbc8d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "43aae3e7-6cfd-485c-b373-3b8d08cb5b0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9f535594-6f28-4591-a672-f68c8ec11b8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0477b634-ed7f-4cbd-a527-0fd8d91034fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49ebc3cc-3cb8-4ccd-8b96-c9c6d2d4606a", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEN6WbqflMiAUiEqrQ2ceEHe5UqsxJ/gM/0So1LNUWGmNpTNX/X5y6Z5joXo6XHTw0Q==", "9388e29c-e8e4-455a-b7a9-9c7d43b2741c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1856623-c9d0-43da-aee7-89cd88ec23b9", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMwc5+9zSOmuTL0f+Kgn0pC7MpQBE1D3j1fFlh5Do046/c8uW2IUTGUCRXXf4I6GqA==", "a81f21bc-fc31-475f-91f6-41fb6420e53b" });
        }
    }
}
