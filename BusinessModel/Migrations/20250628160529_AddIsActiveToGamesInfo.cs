using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToGamesInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "a978a073-b83c-4f64-b73c-93edbbdb947c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a978a073-b83c-4f64-b73c-93edbbdb947c");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Games_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3b1f6e94-c155-4250-a6d0-94dda6cd574b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "c4e5247f-ba8c-4da4-aed7-fddf6423a908");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c3f4d5cc-d431-4108-8a54-f9499b1bd961");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "67672cc5-a5f7-40e8-83e2-0fb23772a214", 0, "0ff095e8-1b04-4643-bf21-67a60c9ed4b9", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEM/CXmPhefg7OI4Rjeb2H2qpgDOe9DyPng+L8//BgYgBHHh6eIIPW6jKuY7Xj3oGqA==", null, false, "9e659633-6eac-46ce-b91a-07175fb01d3c", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1705), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1707), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1708), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1709), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1709), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1682), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1684), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1685), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1686), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1687), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "67672cc5-a5f7-40e8-83e2-0fb23772a214" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67672cc5-a5f7-40e8-83e2-0fb23772a214");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Games_Info");

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
    }
}
