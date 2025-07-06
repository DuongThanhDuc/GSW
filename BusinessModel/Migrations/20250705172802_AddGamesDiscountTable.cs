using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddGamesDiscountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games_Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercent = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Discount", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "9de17032-4be5-4a08-8831-f99af317ef5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "9e540098-6e4f-4c57-9cdb-f67fd3bc81dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "b74e24d5-9580-4919-8c83-209dcc595bd1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e4f9b7-bd27-4c04-bfd7-60345a409766", "AQAAAAEAACcQAAAAEJdEC0hVYxQFl4LtPpvzJ7inkh/45S4ff2sedsRE4Sd0+nWFbE5EU6q4qXoEQ0u69w==", "2ca8e23f-9cdf-44b5-8b72-0182fc02c182" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(693));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 28, 1, 870, DateTimeKind.Utc).AddTicks(669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games_Discount");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "f2724334-8b2e-48a2-91db-b39b3726beda");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "5204f014-a172-4e10-9723-939b3e003a1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c48cd6cb-3a34-4180-9e7f-aeb6f4200e9e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf9b559e-b846-4472-a7d2-7ec93836db2b", "AQAAAAEAACcQAAAAEP1ocQ+jlBWl1l7YZgQOkTeu67YyiXBBby3zOH1cohLBZNgjXsw41+k3P1kJnStB2A==", "5d0a270b-5839-41c4-8ff8-6fbbbf8e120f" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 6, 43, 15, 949, DateTimeKind.Utc).AddTicks(9618));
        }
    }
}
