using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserIdNullableInStoreOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Orders",
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
                value: "c42d66a3-be56-4029-8a3e-0364e37269f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "03156ba6-da8b-466c-8497-ce0e0b8eeb25");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "5679e3bc-e912-4a90-989c-be35ae840018");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f01d45cb-716e-494c-a2bc-3282c12de769", "AQAAAAEAACcQAAAAEC+fZ7DI0IfXdo3OtiyjjjsVi8HXnQykUutdNHUBcSpW2vTMguBHI+6RLlcWu0LLAQ==", "bea2c666-f578-44ad-a8a5-36282a071fc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaca0ba2-3641-46a0-95ac-e7cf56bbff84", "AQAAAAEAACcQAAAAEEcVTa5SvLaJ79+eqhRJR0ZqkUsghnlMdVKsM1HWvPUuysOxrBJuhHuTQSWgEM1Z+Q==", "796fdd65-7c7b-497a-a4bf-bf25860de6e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1809b18-7455-4551-948e-07c3e3b766b3", "AQAAAAEAACcQAAAAEAZApfEIE2XaQ6NBwzKRFE3efeYfQoVZHN1X2SvLKETzMlNBM/WOkkemEUKnW8zulw==", "374102d0-3eee-4baf-a94e-4dacfb4f9b7b" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3069));
        }
    }
}
