using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCodeForStoreOrderTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "c1ea6661-39f0-45d8-aee3-d9f7381a2356");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "eb92d555-3b09-43af-8aed-cda3b9eb7924");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "43759328-d794-45dc-86ac-42be0ab11313");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0bd9072-f488-429d-9a5c-335d02d7d753", "AQAAAAEAACcQAAAAEDtJ0satYKojZwFMHdcgTLmyX4qdsUiCs4Ev/DaqHLVxLVbqUDUgECisYpQMTv6aHw==", "4dc7bf34-4a20-4741-a6e7-ed5e53688070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d462cd3-8e20-4023-8357-590d13d3f159", "AQAAAAEAACcQAAAAEOlxaIgB6+mw4YNpNnhCGJZ5COxQ/ciT44z+a3nLcbmlV4MTaDSPuW7O2AJ6eYVvcQ==", "b106ebeb-93f2-464e-af37-1b84d658225d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 2, 30, 198, DateTimeKind.Utc).AddTicks(736));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "0585be2b-7a4c-46fc-9175-d30d86326fee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "3ed2e215-f172-4daa-b3ec-0e389ef3bbce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "d7ea1550-3e36-48d2-a872-3e9ebda893d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61647709-8cb1-4450-a08c-835aa54c0f62", "AQAAAAEAACcQAAAAEGn9gcqTtK2oyldt3B9ZTCpHtUE5aAEn+OxvV29FV9hBKTj+djyddnlCV+QebZOBKg==", "911b7830-6f6f-4467-b692-0bb72bc908e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a8a2b32-d712-4276-8551-3fecd0136554", "AQAAAAEAACcQAAAAEMG94rv3yeHe/W7YpEiIKhCV38D7FJ1rlnYiNMtJttk70dXVMvPT5mJZv9ToDgS3zQ==", "d6fcb52b-2720-49f9-ac2d-7b11630fc871" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7074));
        }
    }
}
