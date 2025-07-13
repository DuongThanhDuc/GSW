using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class DropGameInfoCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Media_Games_Info_GameId",
                table: "Games_Media");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Games_Media",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Media_GameId",
                table: "Games_Media",
                newName: "IX_Games_Media_GameID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GameID",
                table: "Games_Media",
                column: "GameID",
                principalTable: "Games_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Media_Games_Info_GameID",
                table: "Games_Media");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Games_Media",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Media_GameID",
                table: "Games_Media",
                newName: "IX_Games_Media_GameId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "a732af1a-bd49-40e6-9818-675446d07cd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "aec4afef-547c-46f9-aadc-2ae952fe2363");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "5418f7d2-42ad-4de4-ab91-fdac623f67e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c18f7bc-5c59-41c1-a155-ec9986f62405", "AQAAAAEAACcQAAAAEPm0rB0h30A/mCApudQH3N9P+FpCaXZweDdClOnuypjHrCfbo1kvLo85TeyLvLkoRg==", "8be8b688-e9f1-4c0c-949d-e587bc8a95bc" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 28, 3, 243, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GameId",
                table: "Games_Media",
                column: "GameId",
                principalTable: "Games_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.DropColumn(
                name: "GamesInfoId",
                table: "Games_Media");
        }
    }
}
