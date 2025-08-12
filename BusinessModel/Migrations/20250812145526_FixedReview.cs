using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixedReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarCount",
                table: "Games_Reviews");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpvoted",
                table: "Games_Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "33ecb838-4fad-4e38-a806-f1da70eb3964");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "09e38b9f-b7b6-455d-936d-07fb5070a122");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "02e6cac3-bd68-4887-a4c8-893769b73bc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48093873-162f-43e1-b16a-72055425e6ef", "AQAAAAEAACcQAAAAECy3Vlsdzz2+SktqKUbGL2NmAF0zCaBt7byxB+TZY1QsO/o4l11JIOPuCEIwPrLmAg==", "69ac77be-7c7e-479f-81af-186216bbb1d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2e39115-ad43-4d31-8485-daae7eac693e", "AQAAAAEAACcQAAAAEALZAqEya18R5JXfwhzhwIncyLdX9LDuH7K++/j96U0cUPgWMuvCR2fglhNV4ILQ/w==", "b101687c-b29a-4858-b4b5-1a6114f70f3e" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 14, 55, 26, 45, DateTimeKind.Utc).AddTicks(4549));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpvoted",
                table: "Games_Reviews");

            migrationBuilder.AddColumn<int>(
                name: "StarCount",
                table: "Games_Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
