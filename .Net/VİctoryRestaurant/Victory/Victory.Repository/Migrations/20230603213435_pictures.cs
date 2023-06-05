using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Victory.Repository.Migrations
{
    public partial class pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(8144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(6210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(4955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(3391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 580, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(2266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 580, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 580, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(1833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 580, DateTimeKind.Local).AddTicks(9226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 580, DateTimeKind.Local).AddTicks(8491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 21, 57, 51, 580, DateTimeKind.Local).AddTicks(7772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 0, 34, 34, 852, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "061111ed-900a-4567-b5ea-717d715a0ee4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "2c0187c7-11db-4148-868d-2ab558e26793");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "b334b44e-ea3b-4c79-b2b0-1d62009ca34e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "590a3f1b-26f0-44d6-91fa-f18effac9665", "AQAAAAEAACcQAAAAEDw5O5ySmZqrhnd5LFsx4GSE6NtVxGRh+BYwa/qiqqdv/8y+XV2dUie93J5P6W7YTw==", "6d68c2d5-07b4-45a3-a0a3-7b3ca1e18711" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "568e287b-db15-444f-aab9-6001d96b77d5", "AQAAAAEAACcQAAAAEKVT8FNoab7JZPkOtBKHOh13YRgZgn4T9o5wFC79qTnCZMn9LkdnXIg95jWijhxjmw==", "4811d5a7-5265-4e1e-932e-7241c84d9380" });

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 21, 57, 51, 581, DateTimeKind.Local).AddTicks(3005));
        }
    }
}
