using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddedThread : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67672cc5-a5f7-40e8-83e2-0fb23772a214");

            migrationBuilder.CreateTable(
                name: "Store_Threads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpvoteCount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Threads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store_ThreadReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadID = table.Column<int>(type: "int", nullable: false),
                    ThreadComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpvoteCount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_ThreadReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_ThreadReplies_Store_Threads_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "Store_Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "57fc50e9-b124-4508-9d67-18a5fe812921");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "310143e0-76e4-454a-9266-13a933c4e9d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "80d445a9-e344-4813-9327-6809a623fdd3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ca80fee-9515-40f2-a655-8c95a0e66cd5", 0, "bbf648d4-497d-41c4-b49f-5f77a2a27942", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEM1zosORi5G7LUcJvqzLGzkz4j00MpnMjbu/maxrnXvkLtwKIbAg1LX/wlr7fPNeMw==", null, false, "0347781e-c3a3-4248-b0d0-c6e48634ed80", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3142), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3144), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3146), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3147), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3148), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3117), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3118), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3119), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3121), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 7, 2, 21, 34, 47, 262, DateTimeKind.Utc).AddTicks(3122), "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadReplies_ThreadID",
                table: "Store_ThreadReplies",
                column: "ThreadID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store_ThreadReplies");

            migrationBuilder.DropTable(
                name: "Store_Threads");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "2ca80fee-9515-40f2-a655-8c95a0e66cd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ca80fee-9515-40f2-a655-8c95a0e66cd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3b1f6e94-c155-4250-a6d0-94dda6cd574b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "c4e5247f-ba8c-4da4-aed7-fddf6423a908");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c3f4d5cc-d431-4108-8a54-f9499b1bd961");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "67672cc5-a5f7-40e8-83e2-0fb23772a214", 0, "0ff095e8-1b04-4643-bf21-67a60c9ed4b9", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEM/CXmPhefg7OI4Rjeb2H2qpgDOe9DyPng+L8//BgYgBHHh6eIIPW6jKuY7Xj3oGqA==", null, false, "9e659633-6eac-46ce-b91a-07175fb01d3c", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1705), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1707), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1708), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1709), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1709), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1682), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1684), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1685), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1686), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 28, 16, 5, 29, 433, DateTimeKind.Utc).AddTicks(1687), "67672cc5-a5f7-40e8-83e2-0fb23772a214" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "67672cc5-a5f7-40e8-83e2-0fb23772a214" });
        }
    }
}
