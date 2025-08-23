using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class DeletedGamesUploadandGamesBanner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games_Banner");

            migrationBuilder.DropTable(
                name: "Games_Uploads");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "7956aec6-e632-4793-a65c-85a1cf9e655b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "5f6333cf-a572-4c6f-9d87-578120d915a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c979c1e0-b169-4917-8bfa-92a037f27b71");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e04b26f-af2c-4951-a927-31577e55370c", "AQAAAAEAACcQAAAAEBaIm5ofpNQsSNGr9q8u3imLeBBVWalSAYrL8MZBqKB8B1jJD6SU8a8zMwQwL60Dtg==", "916ed8e6-69a4-40d7-adb3-48a6f57b424b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "383b6e91-d5c6-4fd1-81be-b7da937d8b7a", "AQAAAAEAACcQAAAAEK5nMZf8/hUvm7SSIZZBxwBVfVslG+mlgGLQ0VnyTUWS2NSWE5PdpVX6z1avkRpleA==", "0d63f5f8-28e8-4132-86f2-d252dd61beb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8a7d921-a0de-46cc-925a-f653c6afb8b6", "AQAAAAEAACcQAAAAEKzyTI648eQ3NzlHSnyZl4k+05L2GjuAwJDybDOq0P8fMabyUjV8SVniNDxHrUiUmg==", "aeab6672-d8e2-4d83-a033-cad18d416f2b" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 7, 42, 1, 144, DateTimeKind.Utc).AddTicks(8718));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games_Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games_Uploads",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    DeveloperID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Uploads", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Uploads_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3b421c13-ee47-44bc-863b-cea6018386f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "ef8a11da-b62d-46d2-879f-f566e3a859d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "24ac2c1d-b9ef-49f6-b3d5-f73e234fc273");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b62d3aad-e5b9-4585-9673-8d4d4c4a644d", "AQAAAAEAACcQAAAAEHAMkOpO5TCU2TbE+J0uTAXiZ356EzvObrtIOId2QMPNdjZoK/0oCmJvAWQQ4MLq3w==", "96c47d92-c494-4d3e-aeca-ed8cf4974b15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6504751b-ae52-4163-8625-b3ffc0c697d3", "AQAAAAEAACcQAAAAEP/OxOaJCXFelaoc2Q/PoMGtY24Ohg/tFXjAhpo54BoFxiOMlDoZAuUkcZGpH9yQkQ==", "4c98f29e-4810-448f-81e2-a7c7aae5a903" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecbd47b5-4470-4e02-9a20-e24ec76de54d", "AQAAAAEAACcQAAAAED6bo0vjNThlLjLS1oXaFLYiMXh6iqIN1UXgDEAqHBXSWRuUVLTtLIMrdoBJ9p++Ww==", "d5164302-77bf-4593-b572-ad1af0909c80" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.CreateIndex(
                name: "IX_Games_Uploads_GameID",
                table: "Games_Uploads",
                column: "GameID");
        }
    }
}
