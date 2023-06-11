using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class roles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "386e2f1e-9020-44a2-bb38-8a2dbb275b4a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "15c0547b-d83a-4c1e-ba35-36899fc22a97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2ae73e3c-0d20-4081-8f84-d076a9c2149a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204f2bb9-ca3f-490f-9010-3255228dde22", "AQAAAAEAACcQAAAAEJbS+rRdFB+pxzECJaS6PcpRjc8cyqC12EEs/f6H92EamBkjwZ5hM7NRT4W1/QxGwQ==", "549de2de-8f85-4f95-85c6-b77701725472" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce9986f4-3af2-4014-afae-efa98e2fed66", "AQAAAAEAACcQAAAAEI6DyaSvKQz1oDD/GkvdeWYQs7jYL+lZiTvecQUqvAy3ecR8TAq5gpPKQ2ZJbSbWpw==", "c8aecc33-9c0e-4ba5-872f-3dd6bf3aacb4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
