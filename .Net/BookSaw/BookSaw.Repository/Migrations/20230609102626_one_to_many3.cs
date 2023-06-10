using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSaw.Repository.Migrations
{
    public partial class one_to_many3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Books",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_WriterId",
                table: "Books",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writers_WriterId",
                table: "Books",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writers_WriterId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_WriterId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Books");

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
        }
    }
}
