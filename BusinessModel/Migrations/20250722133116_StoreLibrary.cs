using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class StoreLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "2b0e44fa-d1fe-4915-a207-0bc22182715a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "a66b92e6-05a1-490a-a1c2-02f3cbdd48b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "d21ff49a-f35d-4b82-983f-0df30a25cfbf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96d49a34-30cf-4695-8bc1-76aa52b7e4b7", "AQAAAAEAACcQAAAAEJPgtLV0HRCZJwtini9F25JJ25L1nBMsRDN9hFsWII4qPSbQPApJfnk8vDf7wF7QrA==", "624299ec-5595-4e2b-b7d3-e1a850f5157b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f7c19b3-072c-4a70-a27f-7b18b6b7feef", "AQAAAAEAACcQAAAAEBAj1G1kS6VfYjgXQfEJAMws/ClgptTAGdqQlooLguTMbLToBSgtQiPi8jM8EvHncg==", "9a401568-72c6-4e39-a36d-d39048bda0af" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2677));
        }
    }
}
