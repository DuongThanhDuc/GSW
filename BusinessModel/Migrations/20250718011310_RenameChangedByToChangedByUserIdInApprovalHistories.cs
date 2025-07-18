using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class RenameChangedByToChangedByUserIdInApprovalHistories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangedBy",
                table: "ApprovalHistories",
                newName: "ChangedByUserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "bb56b12e-6412-4ff4-828f-38409207726e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "97c82023-51e7-46d8-a4dc-546b0e9077d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "bf640b06-ae36-48ec-ab8f-6019d6e1277b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5e1c5d8-9bb2-4a63-98d8-85db52641780", "AQAAAAEAACcQAAAAEECEpe6Gez0SlQE8CVgzd/FS3tsisJT6KFqZ+i7wlexODgh7lGfoxtWRWdkcbq3cyA==", "7c7c2c3b-df44-4bac-923f-e33053fc76b4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 1, 13, 10, 549, DateTimeKind.Utc).AddTicks(6678));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangedByUserId",
                table: "ApprovalHistories",
                newName: "ChangedBy");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "e29677f8-1f79-40b2-96a2-25f32eb4203b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "13fcde98-7292-4442-bbe9-9478cbccb988");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c2628ba5-13c5-4998-9bda-a52fb9d44cd3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa78d26c-b56d-4f68-8e0f-2aac9faf03f2", "AQAAAAEAACcQAAAAED1g1XaBpNb16A97Uc9UdCPmYql5q9zUK/o6zyojJShwQNiyBDY89J3avjWGKrHsEw==", "ce23e124-e69d-4664-bab3-9834d515f7d4" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 46, 0, 194, DateTimeKind.Utc).AddTicks(9393));
        }
    }
}
