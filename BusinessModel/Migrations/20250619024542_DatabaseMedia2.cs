using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseMedia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64eea1f5-bf34-4baf-b625-b170200d3a4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "17c16c52-0416-4279-ab69-b06485afa3aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "b01c0b66-3cd2-4997-bf29-332c442b75f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "4e1f486d-8b57-4fae-bc18-0785e350e457");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32c3347c-4800-4921-81dd-8f74f04e6a4d", 0, "da5185bc-2e2d-4291-b9cb-bdd77ab3aab8", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEAh85luNBpuK+DOVtVMG8ZIuzFoTlK8VKORfP7PM7VQqwU1BAqaCWLq6c6LHoBqh3A==", null, false, "d6776c93-836e-47dc-b6aa-4ac1b3d9884e", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6589), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6591), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6603), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6604), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6605), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6564), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6566), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6567), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6568), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6569), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "32c3347c-4800-4921-81dd-8f74f04e6a4d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32c3347c-4800-4921-81dd-8f74f04e6a4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "446cb4dd-5189-412d-9e6a-1cdfac125f62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "b2628c39-9f36-42b0-a1dc-c50735148c4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c74a4bae-115f-48fd-b05e-2753ef7c5031");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64eea1f5-bf34-4baf-b625-b170200d3a4d", 0, "5b0d53c0-18bf-417e-a5b2-81306b75fe34", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEFT2nR4N+zANSpocGXrb9hu9Ti75Lq/p2uSog1y+kYHJ6c0SEdsDngaLQE7pfMxrhg==", null, false, "e75076b0-cbac-4384-a43d-f5bb5c34d898", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9828), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9830), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9831), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9832), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9833), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9808), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9809), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9810), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9811), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 24, 36, 97, DateTimeKind.Utc).AddTicks(9813), "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "64eea1f5-bf34-4baf-b625-b170200d3a4d" });
        }
    }
}
