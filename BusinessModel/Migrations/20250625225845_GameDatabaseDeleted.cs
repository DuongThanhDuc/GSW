using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class GameDatabaseDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game_Database");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fc210d1-79c1-4b61-9164-df5f5a456ebb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "80ee7842-27a8-4b23-9a57-75476c2f90e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "9e1f6c2c-e012-4584-9974-dd092df76b12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "916a9957-35e3-403d-8a3f-666583a55e3a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff609033-9005-4046-b092-de7063c030b4", 0, "46634502-3fde-43d6-9110-de1e181fa1ed", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEJg/7yP8qrEuE6mrBMe4S4XrRGPh5DeAPIagF7Z1MZ91lvE5MQXKrkBYn9WIT3lf2g==", null, false, "c2ea3f5a-9826-4d9b-8fbd-65e1abe15d6f", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5325), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5328), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5329), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5330), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5331), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5304), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5306), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5307), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5308), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 58, 45, 719, DateTimeKind.Utc).AddTicks(5309), "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ff609033-9005-4046-b092-de7063c030b4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ff609033-9005-4046-b092-de7063c030b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff609033-9005-4046-b092-de7063c030b4");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "f8abe99c-d20b-443b-920b-6ed2705a4139");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "9229eedd-9235-4909-934e-c43553cf32f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "ff02aecf-aa51-414d-9496-faa8485b2d39");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9fc210d1-79c1-4b61-9164-df5f5a456ebb", 0, "0ebcedd5-a7a0-4d34-9e10-b3f7514d3b33", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAENqgWnZPoxjxml7D1/SCmvfdTdduk4mXJQjlBD4I88V1WdxtY4v7ttDF9JeiIoNF2g==", null, false, "726c4632-5999-47c5-aa7b-5b06021af457", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(456), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(457), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(458), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(460), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(461), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(434), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(436), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(437), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(438), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(439), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.CreateIndex(
                name: "IX_Game_Database_GameId",
                table: "Game_Database",
                column: "GameId");
        }
    }
}
