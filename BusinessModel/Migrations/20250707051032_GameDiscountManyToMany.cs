using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class GameDiscountManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesInfoID",
                table: "Games_Media",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesInfoID",
                table: "Games_Discount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games_InfoDiscounts",
                columns: table => new
                {
                    GamesInfoId = table.Column<int>(type: "int", nullable: false),
                    GamesDiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_InfoDiscounts", x => new { x.GamesInfoId, x.GamesDiscountId });
                    table.ForeignKey(
                        name: "FK_Games_InfoDiscounts_Games_Discount_GamesDiscountId",
                        column: x => x.GamesDiscountId,
                        principalTable: "Games_Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_InfoDiscounts_Games_Info_GamesInfoId",
                        column: x => x.GamesInfoId,
                        principalTable: "Games_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "ec55a87f-4fdb-438d-a566-8ab4aac6983c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "af98235c-72db-4555-8925-236cb97fc0d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "948f8a5e-8977-4db0-a3a5-0d8c1f742066");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "199e020f-6e7a-4220-af26-68af9c32eaca", "AQAAAAEAACcQAAAAEBNn1RhlW1WP3P9/yknU391kKnQ0uTmy8lv3IuEIS411vVjXwvj4cnqIC245jzx0Fw==", "3df2dc23-2176-4759-8876-fbf75dae966c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.CreateIndex(
                name: "IX_Games_Media_GamesInfoID",
                table: "Games_Media",
                column: "GamesInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Discount_GamesInfoID",
                table: "Games_Discount",
                column: "GamesInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_InfoDiscounts_GamesDiscountId",
                table: "Games_InfoDiscounts",
                column: "GamesDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Discount_Games_Info_GamesInfoID",
                table: "Games_Discount",
                column: "GamesInfoID",
                principalTable: "Games_Info",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoID",
                table: "Games_Media",
                column: "GamesInfoID",
                principalTable: "Games_Info",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Discount_Games_Info_GamesInfoID",
                table: "Games_Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoID",
                table: "Games_Media");

            migrationBuilder.DropTable(
                name: "Games_InfoDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_Games_Media_GamesInfoID",
                table: "Games_Media");

            migrationBuilder.DropIndex(
                name: "IX_Games_Discount_GamesInfoID",
                table: "Games_Discount");

            migrationBuilder.DropColumn(
                name: "GamesInfoID",
                table: "Games_Media");

            migrationBuilder.DropColumn(
                name: "GamesInfoID",
                table: "Games_Discount");

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
    }
}
