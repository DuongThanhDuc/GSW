using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class SystemMediaDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "System_Media");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff609033-9005-4046-b092-de7063c030b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3b4ea136-b7b5-4772-a98f-858c6ca3af93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "a95c3851-ac7d-43c7-8639-ff55c91f63e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "f0e7c487-7fe5-4947-96b4-d870d7f76d93");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a978a073-b83c-4f64-b73c-93edbbdb947c", 0, "f720e645-4f4f-4ded-b6d5-6f3c8e245240", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEIfKWTs0FDjcz7Sh/djipb0mcC8xOAufOlV8vP57qrSHPZjmL0GTGhehEMERl/zDBA==", null, false, "401e9a53-3845-4334-b092-2dc559589a94", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5284), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5285), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5286), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5287), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5289), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5264), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5266), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5267), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5268), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 2, 9, 994, DateTimeKind.Utc).AddTicks(5269), "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "a978a073-b83c-4f64-b73c-93edbbdb947c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a978a073-b83c-4f64-b73c-93edbbdb947c");

            migrationBuilder.CreateTable(
                name: "System_Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MediaURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_Media", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "80ee7842-27a8-4b23-9a57-75476c2f90e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "9e1f6c2c-e012-4584-9974-dd092df76b12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "916a9957-35e3-403d-8a3f-666583a55e3a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff609033-9005-4046-b092-de7063c030b4", 0, "46634502-3fde-43d6-9110-de1e181fa1ed", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEJg/7yP8qrEuE6mrBMe4S4XrRGPh5DeAPIagF7Z1MZ91lvE5MQXKrkBYn9WIT3lf2g==", null, false, "c2ea3f5a-9826-4d9b-8fbd-65e1abe15d6f", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5325), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5328), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5329), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5330), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5331), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5304), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5306), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5307), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5308), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5309), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ff609033-9005-4046-b092-de7063c030b4" });
        }
    }
}
