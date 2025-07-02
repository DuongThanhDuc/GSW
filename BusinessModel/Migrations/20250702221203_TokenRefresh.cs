using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class TokenRefresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddda613a-e48d-4899-add3-9bdd9ae7adba");

            migrationBuilder.CreateTable(
                name: "System_TokenRefreshes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenRefresh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_TokenRefreshes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "72f3906a-a968-4181-bcb2-40e1021c4c79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "24ffcd30-57f8-4b6b-9a2b-805be1caa1a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "01cc8269-2650-4d23-9014-1a833b9e9650");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d3fe8d8-0b68-41bb-8fab-73b7c1624555", 0, "5fde5a18-75be-480e-bab6-bdc0cac3a9e3", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEOkIbTEKS0n8II/0iZpn+BQy1aUp73wvVmt/Cw1FMzFtxNgzk3IhWGP5BOzIrlz+rQ==", null, false, "d0cccdb0-f8a9-4dea-b124-37b0c84743c6", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9559), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9560), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9565), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9567), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9568), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9527), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9528), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9529), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9530), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 12, 3, 573, DateTimeKind.Utc).AddTicks(9532), "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "System_TokenRefreshes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "7d3fe8d8-0b68-41bb-8fab-73b7c1624555" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d3fe8d8-0b68-41bb-8fab-73b7c1624555");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "2c09963f-174b-4a09-ae29-9919fc1fcd45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "6fd1e47a-d389-43a0-8bdb-994acb0ceec2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "bbdddd2c-3e85-4ada-9c5a-d128faf3a522");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddda613a-e48d-4899-add3-9bdd9ae7adba", 0, "5476f1db-aa3c-49b5-9611-24928641d588", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEPVx5rqmGX1LOyZf/c8Z01uNlxza/Eew5HOh499CU8NfFHRyyJCDOpNVcfFbmW+weg==", null, false, "62d28e4b-96f6-4e47-927b-93470af1cf10", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4139), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4140), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4141), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4143), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4144), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4115), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4117), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4118), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4119), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 46, 36, 959, DateTimeKind.Utc).AddTicks(4121), "ddda613a-e48d-4899-add3-9bdd9ae7adba" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "ddda613a-e48d-4899-add3-9bdd9ae7adba" });
        }
    }
}
