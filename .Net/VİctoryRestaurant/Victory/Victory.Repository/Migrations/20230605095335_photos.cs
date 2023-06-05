using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Victory.Repository.Migrations
{
    public partial class photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 623, DateTimeKind.Local).AddTicks(4406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 623, DateTimeKind.Local).AddTicks(1837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 622, DateTimeKind.Local).AddTicks(9323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 622, DateTimeKind.Local).AddTicks(2411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 622, DateTimeKind.Local).AddTicks(1236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 621, DateTimeKind.Local).AddTicks(9976),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "fbfd9013-e924-476b-82e3-ee34b7362f22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "3f01e7ab-76ad-4654-abc1-41b9bb9dd906");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "1b4a4c61-5d98-4f17-ba61-9e51b0db8730");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb4715b-48b7-4876-a7a9-6e029222a881", "AQAAAAEAACcQAAAAEAQ9yi2DfF/Ibyd4OqJjOz6hhikMk8gFvOg7XQ/Jo6GrwDOTj1YVBNgSyJ31wul21Q==", "60d2aa18-e557-45ea-a320-f91d285982e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "850dc2dc-1b29-4147-ab07-34712c627e8b", "AQAAAAEAACcQAAAAECrOBsQPDIKg+5ctFbrGYJcVWSitYMGYN/z5Asmm1qAoLWkbi5E6zLeBNmPK52Lyew==", "eaa34ac4-48e9-492b-b3e8-84d637cbdbb5" });

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 5, 12, 53, 34, 624, DateTimeKind.Local).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 5, 12, 53, 34, 624, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 5, 12, 53, 34, 624, DateTimeKind.Local).AddTicks(544));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(6686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 623, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(5670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 623, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 622, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 622, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(3304),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 622, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(2487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 12, 53, 34, 621, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "d555f3c5-3555-4249-9883-cd930633c87b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "f1da4c98-0631-41f2-84f3-f133edfc2456");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "707d5ddb-f001-4554-bf7f-84711065a771");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a60ebb93-46ee-47a7-a875-e623fb3e837e", "AQAAAAEAACcQAAAAEHcYchrgkRXgxEFyf7yi7674OKqXa8M3A7vMvxkuQgqNwEzVaI+54pbDPWLdYHJMDw==", "5d243bc2-2a4d-4ba3-98b4-6aca8cb4a64f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a358ffa7-285b-4887-8e89-76d639f22067", "AQAAAAEAACcQAAAAEF4DL+g2z725kSKk+w8YJfWjNqzcB5nVFYvhKQoM4VkmMFAu+9mKSRMPvYi2A2Yccw==", "20fe522a-7a9b-4303-9cb9-50dfe2a9c642" });

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Signups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(7973));
        }
    }
}
