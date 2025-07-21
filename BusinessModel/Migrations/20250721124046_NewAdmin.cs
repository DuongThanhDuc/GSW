using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class NewAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "System_TokenRefreshes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3f66102e-8bf4-4ba4-bae0-6218f3ebfa87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "5097e288-cabe-4aec-8dc1-86f053f79c1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "1aef5b7c-769e-4a91-8a17-1b74153ee0f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "415a37de-e267-4acc-b9de-959b6270901f", "AQAAAAEAACcQAAAAECmiy2DPmEoZJ2/pwvmkXtMHW7qYAbP5kK8XWuwxOrxWN51Rwpa6RP1MquLV1CNwkw==", "7b82f9b5-e254-439e-8210-46026be717f5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af", 0, "8d294fa9-89fa-40d1-9b8a-1f4f5f4099b4", "trananhtuan180202@gmail.com", true, false, null, "TRANANHTUAN180202@GMAIL.COM", "TRANANHTUAN180202", "AQAAAAEAACcQAAAAEP8uvmC4vJCOSQqFvGDC5w9l0VX/V4YL2ce2QpQuHDLEL5LuQroGEbYKVQd47KFmEQ==", null, false, "b973767b-5260-474c-9f9c-cabd664dff85", false, "trananhtuan180202" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1196));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af");

            migrationBuilder.CreateTable(
                name: "System_TokenRefreshes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenRefresh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                value: "1fe8fdb1-bc8f-4530-88ed-b997bac4a497");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "aa1e9d25-4355-444c-af14-7c8b36e4e41f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "b4a26bb5-8f59-4ff6-88c5-5ff2716a2384");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c832904-c484-4931-afb5-c86794c6512b", "AQAAAAEAACcQAAAAEN84hsI4MU2R8/vsy/bNNtCe38urLuUBWc3qt0cyHWHvJ2/QjjrchvHwaQe6djAxNw==", "9ef29358-2c51-4405-891d-e6e8ff90af53" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 14, 27, 9, 16, DateTimeKind.Utc).AddTicks(8244));
        }
    }
}
