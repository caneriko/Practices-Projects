using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class one_to_many2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f18f3f39-54eb-43f5-8a57-5d605fb04cb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5ead9275-b575-4acb-bf46-37d4a48535d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6342ff4d-e4e7-4ab4-afd5-1bab40ca8aec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96094591-e9d4-4a60-84af-501dab3e0b7f", "AQAAAAEAACcQAAAAENsZByy3S1eynnD8ePzFXwaM78JU7JSGB1FjCYiB+eSFVIA/q2zyv9bHLotmqBaHAw==", "c2b895d9-5b94-48ae-9e0b-393ad8e91ec8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74385598-66f6-439c-a674-e0cc7e0fc50c", "AQAAAAEAACcQAAAAEKkUDfBCJcFd6fEApVBzED20zok4UCJtYseuFo7uD25GzX22a49uDGSihnRD72R1bg==", "856c5e18-376b-49b1-aa3b-8ce9828e2cce" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e12c7d5d-0c67-4083-933d-4a4a2a06c134", "AQAAAAEAACcQAAAAELaiKWwhZ3HC5exujmdMQSGK+dGQUU24PWcpkRacmPDsRq+J5ztY7RM1bK4Z8Iic9w==", "1eba88fd-df20-4235-a95d-d47e840c8b34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64fcece7-5a5d-497e-8e81-04cb872bf328", "AQAAAAEAACcQAAAAEC58IcJH/VaxNapIidQWEw1ffdYRH/uzgvgt7mXuc886a8xaSOodd8I2RuA+FSw8OA==", "28a111ea-8ebb-4d58-baf6-19d13acbc8d5" });
        }
    }
}
