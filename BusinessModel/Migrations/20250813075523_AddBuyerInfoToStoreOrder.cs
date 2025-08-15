using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddBuyerInfoToStoreOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderCode",
                table: "Store_Orders",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BuyerEmail",
                table: "Store_Orders",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "Store_Orders",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "4dfb923a-38ea-4abb-9503-8ed80b366677");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "f1890529-adf0-4d45-9a21-919e7df4c9a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "5a47e355-5bbe-4a20-8bbd-2f0266ddfc5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d84694bd-2d43-4cc4-a6c1-f43d97f0bbd2", "AQAAAAEAACcQAAAAEAAnYc7agGhYXnQD/Uterlf/H5fze8HKziVSJiPUGAzyCo5OPfpQTl+Qf4q5/0lolQ==", "7e30c0c2-6316-4bff-b792-1e9e42be8549" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2afd5de-90c8-418f-aed1-746433a1bc1a", "AQAAAAEAACcQAAAAEAre3XySQfO4TSswkNZNayRPERMNJ+/x7i+6w38BhDgc4Yp/3+3Hs/eQgulNzTgarA==", "5508e9f4-488e-4243-bf6e-3bf9f6a3c6b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0480472-2510-4942-93d8-1463f14fed58", "AQAAAAEAACcQAAAAEAAXmbCQNpSdFxAWaYQxaT1QIm2tT7Vk0DetdrJoZ5yuHnV8uPODrv9QKWjYVA7+nQ==", "68a2326e-a0cf-4810-b8bf-107caaadc75a" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.CreateIndex(
                name: "IX_Store_Orders_OrderCode",
                table: "Store_Orders",
                column: "OrderCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Store_Orders_OrderCode",
                table: "Store_Orders");

            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "Store_Orders");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Store_Orders");

            migrationBuilder.AlterColumn<string>(
                name: "OrderCode",
                table: "Store_Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "4eeee3fb-ad07-473a-9744-4be925a3b979");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "b6409f28-45d4-420d-b8e4-30a5131d11fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c95c8ff0-6780-49d1-b950-a3183444f67f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a79410-40df-49d5-bfbb-a498d7aacaad", "AQAAAAEAACcQAAAAEGr16HBCJy6WwIaGJFrOF5H0Rdovo4tSRuUHzm6NX/zQbvn0LHaQpxIWJdCZEm4b/w==", "5dbe9193-0e05-444d-97b9-0b44476543e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "349949be-e4c1-4192-b268-d2fe90bbebe6", "AQAAAAEAACcQAAAAEBXza4tgmD4X1r/axqwwXQcb5LrQiTivp9Wi5d1g5Rg1tzdkDJf7n5I/A173+wYh5A==", "b7671b96-47bc-4491-b182-84e04b02a7ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4539b8f7-1ae2-4ae4-aeb1-88aa1b610c19", "AQAAAAEAACcQAAAAEEv0mNu4RoMNGMNbPCqNyeqLUfQOjL5L5rROET/FTATYPm/brrCALBbid5u+49M64w==", "56b319e9-1ba5-4131-b9a9-f129c8291daf" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 38, 7, 537, DateTimeKind.Utc).AddTicks(6806));
        }
    }
}
