using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Victory.Repository.Migrations
{
    public partial class userphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(9401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(8358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(7580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(6614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "0dda6657-7b6e-43a6-a54e-457c8bed9e61");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "912f1fc5-c194-49b5-96dd-f6e39fe400e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "65e89e53-8e8e-4ba7-a5e2-fae4efe92a82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PictureUrl", "SecurityStamp" },
                values: new object[] { "afa4287e-6a6c-4705-9182-2704482e3072", "AQAAAAEAACcQAAAAEFDtfvNVBapYw3N+NyFtE+xFuIu/VZDePpiU0zUGeM+7luO4YTPyzsuq9GHgNcyqfw==", "default_user.jpg", "bc5e03b9-02b7-4d32-9310-20db09cd69c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PictureUrl", "SecurityStamp" },
                values: new object[] { "bcf78e3f-99f6-4dc7-a70f-15c53a90ca79", "AQAAAAEAACcQAAAAEAKxe6hIDO13o7ozhJYDT2gLnGRrOZlbaCMqXycTbM2tvKWzChKRaiVlD35D9EDtcQ==", "default_user.jpg", "2ba43b94-1557-4390-8610-f2ccd66987da" });

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 12, 1, 51, 647, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 12, 1, 51, 647, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 12, 1, 51, 647, DateTimeKind.Local).AddTicks(715));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(8144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(6210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(4955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(3391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(2266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "94464270-0d28-4ac7-a571-66fd9c2c495f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "02323314-dc2e-4d40-aac2-8cd66b371742");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "b1e969ed-0616-4f00-a7ea-3f25afe08b52");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95fa4749-0a2e-4803-86f1-473a959ab3ce", "AQAAAAEAACcQAAAAEPqK73pRprS//NXblU/F6jFFEgtiv0FRh5Na5V2hI0L0LgSnvLTbsXQdPMdRcWnw9Q==", "37688b13-2aa9-4592-a43b-8e31dc9baf9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba34097c-9bdd-449c-adb2-ee79d27f137c", "AQAAAAEAACcQAAAAENkcXoa7z76lTku+Tjujbk/0O3CO+vV++TdNHWJixF+eQY9kXdVpLFxAgycFTlah7w==", "772f8933-8530-40f2-a70e-d63ef53f3321" });

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 0, 34, 34, 853, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 0, 34, 34, 853, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 0, 34, 34, 853, DateTimeKind.Local).AddTicks(303));
        }
    }
}
