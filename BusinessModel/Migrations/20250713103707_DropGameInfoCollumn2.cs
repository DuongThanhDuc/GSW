using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class DropGameInfoCollumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoId",
                table: "Games_Media");

            migrationBuilder.DropIndex(
                name: "IX_Games_Media_GamesInfoId",
                table: "Games_Media");

            migrationBuilder.DropColumn(
                name: "GamesInfoId",
                table: "Games_Media");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "069afae5-e100-4662-9b98-a352aae7ab78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "9114d2e9-d554-4924-a45c-19e2f5d597f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "e5d86527-5b4a-408a-b5a5-8892961206c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdc85742-11cd-497f-b9c7-a029e189a3a4", "AQAAAAEAACcQAAAAEGQa17pDd5itHDG4h9j542hssMttmlQg7+kZm2fGETG6/l1miLEPHcDvkQ/UYyTeog==", "95d66a19-6129-4ea6-9a76-4029f7cded1c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 37, 7, 286, DateTimeKind.Utc).AddTicks(5080));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesInfoId",
                table: "Games_Media",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "f9e52576-69ed-49a3-9aac-ca4e526fc22d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "e1326e79-d5b0-4eb0-8f64-7ebe8cc6869f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "8dcf88c4-60e9-4e6e-a826-9948d3cfe9cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6cacc50-a1ea-4da6-84b3-65b2e14f2e1e", "AQAAAAEAACcQAAAAEJG65zvwNj6oGzKFVjMsXtzWBSNNDB0i6c3ryYJOKPg/tP80S3NbtCc0e9+pBfIvRg==", "da918eec-53e3-4070-9db5-a5755204c8d0" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 33, 42, 319, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.CreateIndex(
                name: "IX_Games_Media_GamesInfoId",
                table: "Games_Media",
                column: "GamesInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoId",
                table: "Games_Media",
                column: "GamesInfoId",
                principalTable: "Games_Info",
                principalColumn: "Id");
        }
    }
}
