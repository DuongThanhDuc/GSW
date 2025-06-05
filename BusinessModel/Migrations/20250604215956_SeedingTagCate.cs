using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTagCate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "de56e04f-5410-4f55-aa14-be10f09c7dcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "f45b3e46-0bc2-4259-827e-102a74c89706");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "8ea1e583-229d-4fd0-baba-3d3a44dedd9c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c610fb3-1112-4bea-89ca-d79e24c69fef", 0, "33d41f88-3a40-45df-a9f2-c3e5e2405299", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAECb4Ez3OGIAea8rQ/BVVd0Z13FlujzGGEdYQyMHuALpnc1kSXVF7N5jKRrbaMRMtJA==", null, false, "985a87d5-0aa5-48a9-8d22-2f568e6b3e6c", false, "admin" });

            migrationBuilder.InsertData(
                table: "System_Categories",
                columns: new[] { "ID", "CategoryName", "CreatedAt", "CreatedBy" },
                values: new object[,]
                {
                    { 1, "RPG", new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2478), "6c610fb3-1112-4bea-89ca-d79e24c69fef" },
                    { 2, "FPS", new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2480), "6c610fb3-1112-4bea-89ca-d79e24c69fef" },
                    { 3, "Puzzle", new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2481), "6c610fb3-1112-4bea-89ca-d79e24c69fef" },
                    { 4, "Simulation", new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2482), "6c610fb3-1112-4bea-89ca-d79e24c69fef" },
                    { 5, "Horror", new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2483), "6c610fb3-1112-4bea-89ca-d79e24c69fef" }
                });

            migrationBuilder.InsertData(
                table: "System_Tags",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "TagName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2458), "6c610fb3-1112-4bea-89ca-d79e24c69fef", "Action" },
                    { 2, new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2461), "6c610fb3-1112-4bea-89ca-d79e24c69fef", "Adventure" },
                    { 3, new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2462), "6c610fb3-1112-4bea-89ca-d79e24c69fef", "Multiplayer" },
                    { 4, new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2463), "6c610fb3-1112-4bea-89ca-d79e24c69fef", "Indie" },
                    { 5, new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2465), "6c610fb3-1112-4bea-89ca-d79e24c69fef", "Strategy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "6c610fb3-1112-4bea-89ca-d79e24c69fef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.DeleteData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c610fb3-1112-4bea-89ca-d79e24c69fef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "72f28bf9-526c-4661-80ab-29705b0dd899");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "bf22fbc7-2759-4265-b2b3-22b6f2a304aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "b92a3acb-c649-4894-a508-48da049cb4b6");
        }
    }
}
