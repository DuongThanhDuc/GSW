using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCodeForStoreOrderTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "0585be2b-7a4c-46fc-9175-d30d86326fee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "3ed2e215-f172-4daa-b3ec-0e389ef3bbce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "d7ea1550-3e36-48d2-a872-3e9ebda893d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61647709-8cb1-4450-a08c-835aa54c0f62", "AQAAAAEAACcQAAAAEGn9gcqTtK2oyldt3B9ZTCpHtUE5aAEn+OxvV29FV9hBKTj+djyddnlCV+QebZOBKg==", "911b7830-6f6f-4467-b692-0bb72bc908e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a8a2b32-d712-4276-8551-3fecd0136554", "AQAAAAEAACcQAAAAEMG94rv3yeHe/W7YpEiIKhCV38D7FJ1rlnYiNMtJttk70dXVMvPT5mJZv9ToDgS3zQ==", "d6fcb52b-2720-49f9-ac2d-7b11630fc871" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 6, 16, 0, 29, 19, DateTimeKind.Utc).AddTicks(7074));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
