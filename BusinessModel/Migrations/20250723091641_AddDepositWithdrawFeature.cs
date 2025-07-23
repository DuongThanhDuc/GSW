using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddDepositWithdrawFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ChangedByUserId",
                table: "ApprovalHistories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "b6b78df3-8e12-434b-afc9-4ab47ecb7cef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "07ad04b3-ee36-41a8-bece-4d29d22f3aad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "f66613c3-7825-4f0b-b896-db66ff4a0f6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eed111c9-7e57-48c5-a049-d56154be9f75", "AQAAAAEAACcQAAAAEEBzQM/SZ4vKZrApk4yIjQ0Tx0rtuu97jJwRj85CHlDIY7yui01nmnOAVZBAGZEDyQ==", "cbaa2d08-8d2e-4e08-ad20-b5b03925fb23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26789b4d-2a6a-4f33-a7a5-e4b3f9bcaa33", "AQAAAAEAACcQAAAAEBJJbCipuvT1Hu8tvIXQPwibaj6h0JhaCgj1EtGDEdmEi/7YsknNZIObkNQQQ0Nl0w==", "2b19b72e-15c8-4b3d-ad20-65fc000adda3" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 16, 41, 600, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ChangedByUserId",
                table: "ApprovalHistories",
                column: "ChangedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalHistories_AspNetUsers_ChangedByUserId",
                table: "ApprovalHistories",
                column: "ChangedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalHistories_AspNetUsers_ChangedByUserId",
                table: "ApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalHistories_ChangedByUserId",
                table: "ApprovalHistories");

            migrationBuilder.AlterColumn<string>(
                name: "ChangedByUserId",
                table: "ApprovalHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
        }
    }
}
