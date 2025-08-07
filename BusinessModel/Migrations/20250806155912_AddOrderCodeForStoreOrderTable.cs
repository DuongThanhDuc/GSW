using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCodeForStoreOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "7821f414-b210-4207-9e01-91cbc1f92850");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "207cd9f2-a649-4604-a25b-b4f930e80860");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "2c15bbbb-5ebb-411d-93ad-795fcb17435b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feb7a938-9089-49d8-b356-2412f66657ee", "AQAAAAEAACcQAAAAEPneo7TybfPo6r22aie3IwcXoeUzXTABJuq4iX/8myAaKOOAQvLYyhIxzfbJbe8l5A==", "d7ff9a37-74a0-4203-8ecc-071e8a93b144" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be20d74d-f35d-485b-9df6-3d3611366fb9", "AQAAAAEAACcQAAAAEJ/dsV4gJOOnSn4khoOEaNYm4rbNLbhwhrVGHLoM5yFz5Xad/hHQQXei5cQJ0sxSdg==", "bcc53a65-ee29-43e9-88d2-91d0bd36e117" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 15, 59, 12, 288, DateTimeKind.Utc).AddTicks(2140));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
