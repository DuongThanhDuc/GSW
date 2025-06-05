using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c610fb3-1112-4bea-89ca-d79e24c69fef");

            migrationBuilder.CreateTable(
                name: "Store_Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_Cart_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "8e42382e-8b9e-4a89-8431-ad32a48ea40f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "ad0a03f8-3101-49a1-9dba-295214cdf2cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "90336768-94c4-4e3b-8ba8-0391f27302fc");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66", 0, "82a7a248-c017-438c-a309-f5f943ed6b22", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEBi1MzrhDJhvpX68hv3GLvdZgTIcqZfTcXgm03iTZG5OE34Pbo4Y634qUQKMnwMYpw==", null, false, "fded1432-b677-43a5-a6cc-f978b6f8a757", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5675), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5676), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5678), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5679), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5680), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5656), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5658), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5659), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5660), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 23, 45, 47, 882, DateTimeKind.Utc).AddTicks(5661), "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_Cart_GameID",
                table: "Store_Cart",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store_Cart");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66");

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

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2478), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2480), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2481), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2482), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2483), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2458), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2461), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2462), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2463), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 59, 56, 438, DateTimeKind.Utc).AddTicks(2465), "6c610fb3-1112-4bea-89ca-d79e24c69fef" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "6c610fb3-1112-4bea-89ca-d79e24c69fef" });
        }
    }
}
