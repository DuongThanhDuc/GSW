using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "Store_Orders");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Store_Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "88d3fdb4-be28-47c0-b0db-d2c1909c6349");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "c754da11-d91a-430d-9c49-d59dbc62d4be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "0c985846-465e-45cd-b7f5-297cda211f79");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91c49368-d1ec-4df7-8c39-d27b5733d872", "AQAAAAEAACcQAAAAEJDUbEjQsHMCzYI9nBTFqPsNAA2ZK12eCXBZzTEDK5dHEgAU4DJr9HCq+R5+GZ8jEQ==", "8d8eee89-2108-4afa-89f3-3d393873bc38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e799cf3a-5d92-4889-ae6c-bb1d763f1c79", "AQAAAAEAACcQAAAAEMbSFlSaqVsCuczFiXuAD37mW1qCJVUQxq3uvBFp/60AqN0efV3psReobAfSRiICLQ==", "0972818f-e738-4bea-931e-8f18a2cf4dc4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae1fa6dc-fccd-465f-9bfa-5337f24e6cef", "AQAAAAEAACcQAAAAENyx6azPGZfSw4FZG0heWUQtoYMG+fT3xiL6f3s6Fm09pohas6pFYzoeoyvMsigunw==", "75f51c93-aa22-4040-bf3d-32bc135491bd" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 9, 33, 23, 550, DateTimeKind.Utc).AddTicks(5465));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: "90793a68-a050-4837-a902-76508d3a29fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "7a67340c-1a42-41b5-b004-6a98aed24baa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "9a95188b-d5e5-480d-899d-7e65902b27a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899906da-099d-4a42-9e35-c40161a214fb", "AQAAAAEAACcQAAAAEDKrnNqS8OFtpzgZF41lfkAs+TDe5t6Xnuvvq7NxzmsHRqOC/eQEhA2uQEAcg+6TTg==", "a3a7612a-0ecd-4b6f-91e7-a0b07bb4ed48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e2bbb5f-52df-40df-b7e4-3b45fb76ca52", "AQAAAAEAACcQAAAAEEgRkRgpdZFyl2DFxTnOTdNooP3qZq+ZsdAgb1Ddaiqy3ZMyjNjOL4jabdeeunw42Q==", "a2099c47-a37f-4b8a-8153-230f73df6b89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dadeef75-3bf0-47d8-96df-8b84efe5224c", "AQAAAAEAACcQAAAAEG+f26hnrRxwQOM5umsgbEk2t0eqJU5MddElVt2kswhFIB4CfID9+/UOTRPMLdbcNg==", "6260064f-260c-4d5a-8a0c-cada88d24f8c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7854));
        }
    }
}
