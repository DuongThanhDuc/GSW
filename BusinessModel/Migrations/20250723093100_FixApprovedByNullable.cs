using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixApprovedByNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "DepositWithdrawTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "675f3a30-44ee-48ec-aaed-755f7a4f1234");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "03e94273-7e37-45c4-acb9-21802b121f0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "419a31cb-72d9-4493-86e4-77dff9cec94c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95c41989-046b-4933-9403-bdce317d66a3", "AQAAAAEAACcQAAAAEDaxsIw26lrsdNe4hlo52r4V9ESgANaQZrDbYRtbt0Hu/3XJLmwOBUeQ9YDZJYyt2A==", "8118da5f-11d3-4bb5-a4aa-5afd8a51ba05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9dd2108-49d9-4f88-aadc-dd1c4e6e41f5", "AQAAAAEAACcQAAAAEM6VCBOY1VGedA/M06WdnTpFUUTnlMIzc+zJBjx2mX/CWRfdf3fhqJI88PAV2b6+mQ==", "c71153b2-7c5e-400a-8b9d-81f27b08d533" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3067));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "DepositWithdrawTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
