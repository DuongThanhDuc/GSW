using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class MediaLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e");

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
                name: "Games_Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    MediaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Media_Games_Info_GameId",
                        column: x => x.GameId,
                        principalTable: "Games_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_Library",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamesID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Library", x => x.ID);
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
                value: "41353894-6efe-464e-80ab-3da4f1c376f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "17109a68-a695-4b1c-afad-f173863d4877");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "d7c4c922-7c4d-4076-8080-a5ad12cbe80d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38eb5025-94ac-4d3a-9e63-9ff020e24cd8", 0, "9ac87267-7160-4b97-8a0b-5d01e233bec5", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEGlAsE8LI/L3RA6yur7KFeiUQZedhX/ZR19YF1/mC8zYT4vxnNnu1aWPNEZHb1vb3A==", null, false, "ac1bdb75-2562-43f1-b419-0d5d1153b16f", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2235), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2236), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2238), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2239), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2240), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2214), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2216), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2217), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2218), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2219), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.CreateIndex(
                name: "IX_Game_Database_GameId",
                table: "Game_Database",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Media_GameId",
                table: "Games_Media",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game_Database");

            migrationBuilder.DropTable(
                name: "Games_Media");

            migrationBuilder.DropTable(
                name: "Store_Library");

            migrationBuilder.DropTable(
                name: "System_Media");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38eb5025-94ac-4d3a-9e63-9ff020e24cd8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "fc92cc47-3020-4d56-9d85-cf6591a4ba8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "55cfb46c-c24b-4aba-8709-1065250a84d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "7521a044-432c-4c1d-80d8-1f002d827cdd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e", 0, "7787af62-61a5-45f0-866f-f8639d2311a0", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAECa0OVkBlYHb3a3gxMHkPEHLshgoBTPCoyqRfySLkaZN9DKMqOuKKqZt9c5YQW3HUA==", null, false, "a02d9d35-e541-4396-808a-804300fa960d", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5879), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5881), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5882), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5883), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5884), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5857), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5859), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5860), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5861), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 23, 22, 59, 47, 885, DateTimeKind.Utc).AddTicks(5862), "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });
        }
    }
}
