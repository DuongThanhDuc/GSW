using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "1d6aedec-26a9-46ff-b110-83004d4ca430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "b1d0180b-9de9-456a-bb73-5f72c3dd68cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "49775eee-5832-4979-be84-bf19075b3732");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79509a4e-5ae7-4b96-862b-d515da3addb0", "AQAAAAEAACcQAAAAEDqmb9FVJ1qevquxSqZlMZZ/x8ey2NyMZgLb3/6KP4jE7afQmmHFbECC/s07XxOGOw==", "1da0c20b-0db2-4249-be0e-2af2403d9dc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9399b3de-00d5-4864-9595-3c80fe9498d5", "AQAAAAEAACcQAAAAEDIi5LeHw3zKd7Oj8TTfsvV57Z3MQSUXnv7E0a6gicaewkN4b54xqzoa4B9D+9ZZBA==", "cdfcffc0-ad38-4884-bb6a-137feb5e07fb" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af", 0, "fed5653f-1e64-44f5-ad90-da7fb73461c9", "phong260702@gmail.com", true, false, null, "PHONG260702@GMAIL.COM", "PHONG", "AQAAAAEAACcQAAAAEDk9pcV/3AgMP+srGo35ktvwgEPm/6OplGIzFsH+/5vFSyQqjA3W7iVCSW8oUNPbLQ==", null, false, "a12d447b-7c4f-4cfc-b8fc-295b882079f9", false, "phong" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 56, 23, 429, DateTimeKind.Utc).AddTicks(8968));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af");

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
    }
}
