using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaIdentityMvcApp.Repository.Migrations
{
    public partial class ideneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MyProperty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MyProperty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MyProperty",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MyProperty",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MyProperty");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MyProperty");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MyProperty");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MyProperty");
        }
    }
}
