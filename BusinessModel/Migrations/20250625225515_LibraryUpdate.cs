using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class LibraryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38eb5025-94ac-4d3a-9e63-9ff020e24cd8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "f8abe99c-d20b-443b-920b-6ed2705a4139");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "9229eedd-9235-4909-934e-c43553cf32f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "ff02aecf-aa51-414d-9496-faa8485b2d39");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9fc210d1-79c1-4b61-9164-df5f5a456ebb", 0, "0ebcedd5-a7a0-4d34-9e10-b3f7514d3b33", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAENqgWnZPoxjxml7D1/SCmvfdTdduk4mXJQjlBD4I88V1WdxtY4v7ttDF9JeiIoNF2g==", null, false, "726c4632-5999-47c5-aa7b-5b06021af457", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(456), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(457), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(458), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(460), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(461), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(434), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(436), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(437), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(438), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 55, 15, 748, DateTimeKind.Utc).AddTicks(439), "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_Library_GamesID",
                table: "Store_Library",
                column: "GamesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Library_Games_Info_GamesID",
                table: "Store_Library",
                column: "GamesID",
                principalTable: "Games_Info",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Library_Games_Info_GamesID",
                table: "Store_Library");

            migrationBuilder.DropIndex(
                name: "IX_Store_Library_GamesID",
                table: "Store_Library");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "9fc210d1-79c1-4b61-9164-df5f5a456ebb" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fc210d1-79c1-4b61-9164-df5f5a456ebb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "41353894-6efe-464e-80ab-3da4f1c376f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "17109a68-a695-4b1c-afad-f173863d4877");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "d7c4c922-7c4d-4076-8080-a5ad12cbe80d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38eb5025-94ac-4d3a-9e63-9ff020e24cd8", 0, "9ac87267-7160-4b97-8a0b-5d01e233bec5", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEGlAsE8LI/L3RA6yur7KFeiUQZedhX/ZR19YF1/mC8zYT4vxnNnu1aWPNEZHb1vb3A==", null, false, "ac1bdb75-2562-43f1-b419-0d5d1153b16f", false, "admin" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2235), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2236), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2238), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2239), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2240), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2214), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2216), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2217), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2218), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2025, 6, 25, 22, 52, 59, 281, DateTimeKind.Utc).AddTicks(2219), "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "38eb5025-94ac-4d3a-9e63-9ff020e24cd8" });
        }
    }
}
