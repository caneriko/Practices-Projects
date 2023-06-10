using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class deneme23213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1b56ec6b-200d-4122-ab26-fd55c6e07191");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4df2e116-f58f-41ba-ae55-b8f7f0bf21b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f9ca18f0-56aa-4b0e-b8e6-44140650ea1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a0fb2c7-149d-47eb-8ed5-6b6c44fb73ec", "AQAAAAEAACcQAAAAEO1bk5PUfmq/vcqzuEesZsdfbd+TbBvmJhTDswm897XgfnWRlKBAsZdmK0CCk+UpeQ==", "601e3984-7ea5-428c-8573-82d28e64da18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac3d76fa-1dfd-4b4e-baeb-89174da126a7", "AQAAAAEAACcQAAAAEIatin2bLWq7EiJJNO2nCuPFZiA0VoK0TCAAf7I0bIYPZhwvwlyIu+tsMLkRPlsnwA==", "3239af1d-e136-4718-9e9f-a96616772987" });
        }
    }
}
