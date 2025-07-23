using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddDepositWithdrawTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepositWithdrawTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositWithdrawTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositWithdrawTransactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "6cee9bcf-8f3d-4c32-8b84-f4bcb0458c90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "758a2144-a62b-4f3b-8be4-cc735a79284a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "db4c1047-f1c3-46a7-b6c1-0188462fe5d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f53366f0-fcb4-47e0-9402-0888751fd73c", "AQAAAAEAACcQAAAAEPsUBVMbGTZWvAcSkad1KWRIRH/6N9JaCz9lzXIFQFsYKJMeJ1bnLRALM9uDLhQn5A==", "c6c9796c-ef0e-47d2-bbe9-581a993f16a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eae49ee7-513a-43f9-ab1f-eeaaa47dee4d", "AQAAAAEAACcQAAAAEDbgTmNSV/ziATRDlbcm2liq3QrhpuojEQOAhB2E2mRGLMeQ7W0Rz3KWS/7QaWxrKQ==", "fe1cda06-ed5a-4c20-b325-675948cb7ef9" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(63));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 3, 57, 804, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.CreateIndex(
                name: "IX_DepositWithdrawTransactions_UserId",
                table: "DepositWithdrawTransactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositWithdrawTransactions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "49c7e552-af20-40ca-a750-bf0fb1280039");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "b050dfce-282d-492e-9299-ab9d747690b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "e96f3ae1-7302-4acd-abb7-a7eef166009a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4960aaa2-afda-4167-9a4e-b903ec9abe06", "AQAAAAEAACcQAAAAEPlHX9kzbkHDbekar1fgVzf/8U/EFlb6NOPRb96Ny/NQudUAKvccWO/rJ4D7NcXMlA==", "f3bbcf8b-bfb9-44a0-b5b8-22b0c7c219b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5390c7fe-c17d-47cc-9095-3b02952b4a2c", "AQAAAAEAACcQAAAAEG/zbIVDhAyg6X2N8My/UfFGWJnttCYWVWMrk6ZCjpGwEPZoqc1ilIlCFMEUYzNOUA==", "af87da8b-886f-4a11-b627-4882721b4f86" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 13, 31, 16, 718, DateTimeKind.Utc).AddTicks(2385));
        }
    }
}
