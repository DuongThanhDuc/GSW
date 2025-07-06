using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddGamesBannerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games_Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Banner", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "7c9b8203-5c82-4e40-af99-77a7dd428cfb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "0c63421b-606e-4f78-afc0-a7f1cb4db01a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "f4e31e7d-818d-477e-94a0-d8d8492f4071");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "651fb501-4798-4506-95c3-942c188befb5", "AQAAAAEAACcQAAAAEDRcx47IIXgAhjRAlsfA6EADbLHXIhxpFgoR9BZScyxw6oWvS/soAC9/C3uwsd8e1A==", "98460ee4-101b-4636-994a-8b31a1dc65ac" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(948));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(952));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 6, 14, 2, 29, 130, DateTimeKind.Utc).AddTicks(923));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games_Banner");

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
    }
}
