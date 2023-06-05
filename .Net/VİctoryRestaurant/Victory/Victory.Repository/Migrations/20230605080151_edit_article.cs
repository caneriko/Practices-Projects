using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Victory.Repository.Migrations
{
    public partial class edit_article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(6686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(5670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(3304),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(2487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Signups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(9401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(8358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(7580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(6614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 1, 51, 646, DateTimeKind.Local).AddTicks(5077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 11, 1, 50, 817, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afa4287e-6a6c-4705-9182-2704482e3072", "AQAAAAEAACcQAAAAEFDtfvNVBapYw3N+NyFtE+xFuIu/VZDePpiU0zUGeM+7luO4YTPyzsuq9GHgNcyqfw==", "bc5e03b9-02b7-4d32-9310-20db09cd69c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcf78e3f-99f6-4dc7-a70f-15c53a90ca79", "AQAAAAEAACcQAAAAEAKxe6hIDO13o7ozhJYDT2gLnGRrOZlbaCMqXycTbM2tvKWzChKRaiVlD35D9EDtcQ==", "2ba43b94-1557-4390-8610-f2ccd66987da" });

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
    }
}
