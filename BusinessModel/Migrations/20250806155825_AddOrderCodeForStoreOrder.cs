using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCodeForStoreOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Store_Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "57badb08-aee0-4e42-8a3e-dbf9c15892c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "fae92cf6-99d3-4314-b730-05c25fa1f1c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "bb3e7115-3204-460e-85dc-35df35bddc0d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c397dd9f-8227-4e42-a4fe-51aeee1c9679", "AQAAAAEAACcQAAAAED1VkVYToGkuSQbwz3rOOUO4/DZD9bpQw2aO/bRs9Vu+UO+M4SbU38e5S8gGh49M5A==", "cf6d277a-eaa3-4f98-89d3-232f6635f91e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8f024e0-05a2-4564-a608-0344a088c0d4", "AQAAAAEAACcQAAAAEJyqaXDht8tjK3pjynhw+6U66KDDn2IJhq7qpnux2Q0rEnlPYladKzdwHxXWZLqStg==", "d6301a90-64b0-4ce9-bfc5-d3d923dd7402" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 58, 25, 95, DateTimeKind.Utc).AddTicks(904));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Store_Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "7b75142a-ff79-4650-a4d9-ec6c81bae0ee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "98042911-812e-4400-896c-629254017592");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "03384d7e-ebab-4769-a051-164dcdce8b3e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19a0533f-81e5-4ebe-af0e-fe20892a45e1", "AQAAAAEAACcQAAAAEBsufUAIwZHL9gI68sqbmQl0kNW59weO48LkYFqXKiFILzCj0Mwo3H8Lw/lZix/xDw==", "c00c93b9-27c5-4842-ac57-69eff7638db7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e77b5657-453f-4576-8645-fc031ead9c60", "AQAAAAEAACcQAAAAEOqbd/JUfBkAR91qyS2PZrHXe28kbUguKyW7bMJBEtO+kFC2ZjaI87kQ86QzqLM+eA==", "170b0724-1b7d-4bf9-9fa3-a3619c323e90" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7410));
        }
    }
}
