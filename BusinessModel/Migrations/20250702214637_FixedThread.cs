using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixedThread : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ca80fee-9515-40f2-a655-8c95a0e66cd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "2c09963f-174b-4a09-ae29-9919fc1fcd45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "6fd1e47a-d389-43a0-8bdb-994acb0ceec2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "bbdddd2c-3e85-4ada-9c5a-d128faf3a522");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddda613a-e48d-4899-add3-9bdd9ae7adba", 0, "5476f1db-aa3c-49b5-9611-24928641d588", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEPVx5rqmGX1LOyZf/c8Z01uNlxza/Eew5HOh499CU8NfFHRyyJCDOpNVcfFbmW+weg==", null, false, "62d28e4b-96f6-4e47-927b-93470af1cf10", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4139), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4140), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4141), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4143), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4144), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4115), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4117), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4118), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4119), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4121), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ddda613a-e48d-4899-add3-9bdd9ae7adba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddda613a-e48d-4899-add3-9bdd9ae7adba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "57fc50e9-b124-4508-9d67-18a5fe812921");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "310143e0-76e4-454a-9266-13a933c4e9d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "80d445a9-e344-4813-9327-6809a623fdd3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ca80fee-9515-40f2-a655-8c95a0e66cd5", 0, "bbf648d4-497d-41c4-b49f-5f77a2a27942", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEM1zosORi5G7LUcJvqzLGzkz4j00MpnMjbu/maxrnXvkLtwKIbAg1LX/wlr7fPNeMw==", null, false, "0347781e-c3a3-4248-b0d0-c6e48634ed80", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3142), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3144), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3146), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3147), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3148), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3117), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3118), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3119), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3121), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3122), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });
        }
    }
}
