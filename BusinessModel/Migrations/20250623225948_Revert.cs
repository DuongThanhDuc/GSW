using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class Revert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game_Database");

            migrationBuilder.DropTable(
                name: "System_Media");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32c3347c-4800-4921-81dd-8f74f04e6a4d");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d579740-98cb-4e23-bc69-d3d3c3ca9e6e");

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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    GameFilePathURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MediaURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                value: "17c16c52-0416-4279-ab69-b06485afa3aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "b01c0b66-3cd2-4997-bf29-332c442b75f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "4e1f486d-8b57-4fae-bc18-0785e350e457");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32c3347c-4800-4921-81dd-8f74f04e6a4d", 0, "da5185bc-2e2d-4291-b9cb-bdd77ab3aab8", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEAh85luNBpuK+DOVtVMG8ZIuzFoTlK8VKORfP7PM7VQqwU1BAqaCWLq6c6LHoBqh3A==", null, false, "d6776c93-836e-47dc-b6aa-4ac1b3d9884e", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6589), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6591), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6603), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6604), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6605), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6564), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6566), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6567), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6568), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 19, 2, 45, 42, 314, DateTimeKind.Utc).AddTicks(6569), "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "32c3347c-4800-4921-81dd-8f74f04e6a4d" });

            migrationBuilder.CreateIndex(
                name: "IX_Game_Database_GameId",
                table: "Game_Database",
                column: "GameId");
        }
    }
}
