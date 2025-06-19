using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b42b9ed0-124a-45ed-ba26-9b4fbbfbbf66");

            migrationBuilder.DropColumn(
                name: "CoverImagePath",
                table: "Games_Info");

            migrationBuilder.DropColumn(
                name: "InstallerFilePath",
                table: "Games_Info");

            migrationBuilder.AddColumn<int>(
                name: "CoverImageID",
                table: "Games_Info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstallerFileID",
                table: "Games_Info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Game_Database",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameFilePathURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Database", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Database_Games_Info_GameId",
                        column: x => x.GameId,
                        principalTable: "Games_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "System_Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_Media", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Game_Database_GameId",
                table: "Game_Database",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game_Database");

            migrationBuilder.DropTable(
                name: "System_Media");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "64eea1f5-bf34-4baf-b625-b170200d3a4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64eea1f5-bf34-4baf-b625-b170200d3a4d");

            migrationBuilder.DropColumn(
                name: "CoverImageID",
                table: "Games_Info");

            migrationBuilder.DropColumn(
                name: "InstallerFileID",
                table: "Games_Info");

            migrationBuilder.AddColumn<string>(
                name: "CoverImagePath",
                table: "Games_Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstallerFilePath",
                table: "Games_Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
