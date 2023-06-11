using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7db2618c-75c0-497d-9fcc-79a246941197");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "71fd2c22-c92c-46d2-921c-a249a1a17798");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5c007080-4b83-4486-b20f-a8ffc682140e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67388117-8f81-4419-b769-a02386ef8d40", "AQAAAAEAACcQAAAAEDkfMR0XvmNJHogIhlG6JriePaGpnYrpM+TEMdmvpvD1YjWXBa3Rw1rKvOiU0i1o1g==", "b822c92c-8ebf-4d6f-99e8-057fb93d5f34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39097b05-5e41-4d70-83d8-b58b5c14b8af", "AQAAAAEAACcQAAAAECwd74jjhaXIxCHh33VGN/3UFJBZZx7AY7biOBHdNkZQ+aIq12Cbuvp1Go2MYlczxw==", "c8bee9ee-a072-432a-95e6-6bd3b1399f2b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c9e7f53c-7e8e-493a-984c-89bd2810c9a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e5f7fc88-4752-44f9-ba50-bff2fe1f1e95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6f5ea6c0-9ee7-4b8a-acfa-fd3f554cf249");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62616d24-ed48-47e9-9259-b510a5bf70db", "AQAAAAEAACcQAAAAEEvbJ/ORz+OXyCt0TgNy7cgW/l49Hky10aGPu7E9ET8kx1mxuo0xnkGaU3Aidtustg==", "f431aeff-502c-4f96-9313-440cfa611307" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d87d50aa-60a1-48b7-a569-ba3a8b02b8f5", "AQAAAAEAACcQAAAAEOey2LBCHdp/IVZ9Lh8Ynf6cvwlTE3PhfNrBSuHxwui4VVvvN6xY2cYvrGezu/2BlA==", "8880939b-c651-4035-a98d-9184a6442f34" });
        }
    }
}
