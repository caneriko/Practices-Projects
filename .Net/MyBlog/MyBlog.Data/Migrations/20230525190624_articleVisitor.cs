using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class articleVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1a19ef07-821a-4be7-8126-da23cadba9e8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3fa17dab-6619-4a3a-bf20-1a0451fbe6e1"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1944bb60-607f-4455-a4c8-4d43cadb7f7c"), new Guid("760ac322-6cfc-44ee-8923-a44060701322"), " burası makale içeriği", "Admin Test", new DateTime(2023, 5, 25, 22, 6, 23, 930, DateTimeKind.Local).AddTicks(2582), null, null, new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("967b3995-b6f0-4c09-97f9-c5ac3d9d7a02"), 15 },
                    { new Guid("41c148bb-d7c8-4014-a67f-4247bd7c2b13"), new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"), " burası makale içeriği", "Admin Test", new DateTime(2023, 5, 25, 22, 6, 23, 930, DateTimeKind.Local).AddTicks(2596), null, null, new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), false, null, null, "Visual Stüdyo Deneme Makalesi", new Guid("bd195f88-9f84-4bba-81f4-727c97e4296d"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("597b554d-2ec6-48c0-afce-c8f7a7a61b5c"),
                column: "ConcurrencyStamp",
                value: "9f6e54ea-0337-4113-b494-74817574d90a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("90b85770-f756-4922-82bd-2fcd1b4f97f9"),
                column: "ConcurrencyStamp",
                value: "66b8220a-4386-41b4-8697-6a6ee25356c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6fc33d0-b968-454d-8900-66b1e36f2102"),
                column: "ConcurrencyStamp",
                value: "0a5cc093-15bc-4efd-9735-a0e82f79c1ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("967b3995-b6f0-4c09-97f9-c5ac3d9d7a02"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99089360-d7f8-47a0-8070-c90f765e4ae1", new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), "AQAAAAEAACcQAAAAEOZJCgepxqWCjr272HXarhDzksR/kjugJe0B9HlAHII7Fao9saAg5IBWPu4ZMb4c1g==", "9a3ea549-b396-42cb-9f95-b2b2f9ab6de8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd195f88-9f84-4bba-81f4-727c97e4296d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9a0fe50-6273-4bed-a355-f73b7255fe2f", "AQAAAAEAACcQAAAAEMzyaGrzC7Fpn414be3eL9r76HfN/4D5gE+0wqjiyW0D/W0BUUdRkCbtRM9cdLXtGQ==", "31228b80-fdaa-4e62-bea6-ca66369ee0ef" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 6, 23, 930, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760ac322-6cfc-44ee-8923-a44060701322"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 6, 23, 930, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 6, 23, 930, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 6, 23, 930, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1944bb60-607f-4455-a4c8-4d43cadb7f7c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("41c148bb-d7c8-4014-a67f-4247bd7c2b13"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1a19ef07-821a-4be7-8126-da23cadba9e8"), new Guid("760ac322-6cfc-44ee-8923-a44060701322"), " burası makale içeriği", "Admin Test", new DateTime(2023, 4, 6, 15, 4, 39, 391, DateTimeKind.Local).AddTicks(9109), null, null, new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("967b3995-b6f0-4c09-97f9-c5ac3d9d7a02"), 15 },
                    { new Guid("3fa17dab-6619-4a3a-bf20-1a0451fbe6e1"), new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"), " burası makale içeriği", "Admin Test", new DateTime(2023, 4, 6, 15, 4, 39, 391, DateTimeKind.Local).AddTicks(9120), null, null, new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), false, null, null, "Visual Stüdyo Deneme Makalesi", new Guid("bd195f88-9f84-4bba-81f4-727c97e4296d"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("597b554d-2ec6-48c0-afce-c8f7a7a61b5c"),
                column: "ConcurrencyStamp",
                value: "861cc011-c566-4058-84ca-48be3cbd6e1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("90b85770-f756-4922-82bd-2fcd1b4f97f9"),
                column: "ConcurrencyStamp",
                value: "e58e1112-0ef5-4b9f-a3e1-873c545754cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6fc33d0-b968-454d-8900-66b1e36f2102"),
                column: "ConcurrencyStamp",
                value: "95179398-3fd6-43c7-b2ef-3eb4cddf748f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("967b3995-b6f0-4c09-97f9-c5ac3d9d7a02"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0cf0619-80b5-4766-9ed8-1b95aa40c14e", new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"), "AQAAAAEAACcQAAAAEPXMuX1c4oR78tVvirx4dbVipzO/az2a+EFsnodlx2sqKbznVosN8PnvKC0rDOlVEg==", "e35d6992-b4c3-4c0a-aba4-11272a7e68e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd195f88-9f84-4bba-81f4-727c97e4296d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d30bb61a-f580-463e-bbda-c37066b1b240", "AQAAAAEAACcQAAAAEGOGV6SkYberBGXoMGqFPYdHgwDFRcyAkcBv4LI3nIkYb/ELuGyb9trcySVKBr2pkw==", "426e1e1a-a07f-477f-994c-cc3670d05a4d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2644b758-be40-4e75-8d8b-82ec82cedca9"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 6, 15, 4, 39, 391, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760ac322-6cfc-44ee-8923-a44060701322"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 6, 15, 4, 39, 391, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3435c2a1-305d-4105-9bbc-9f7327686546"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 6, 15, 4, 39, 391, DateTimeKind.Local).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c213fa88-5ad0-4b26-a1c9-9d1d793daa3f"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 6, 15, 4, 39, 391, DateTimeKind.Local).AddTicks(9791));
        }
    }
}
