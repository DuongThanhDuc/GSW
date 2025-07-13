    using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixedGamesMedia : Migration
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
                value: "f350d986-a485-4746-84da-c569fc48e80c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "27c52fa4-22f7-404e-8d92-89520120a426");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "509f9a40-63fd-4f3f-916d-717e52ab9316");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b69d7880-fa56-41e6-a29e-36f19e1021ba", "AQAAAAEAACcQAAAAEM5IYPTFRNBL9JzzGPIqo+K11J6BXp3UvOIpwKdwuaa323KGuowt+z4Nqo5yOylB2Q==", "719c491b-2fb5-4f7e-af67-c7a28364b1da" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 10, 23, 42, 208, DateTimeKind.Utc).AddTicks(392));

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
                value: "7bceac09-6682-49a8-9522-6ccfa2b36347");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "134518b8-7687-42a6-a2af-eac2ed19afcb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "8fecd58a-0a13-462a-8b4d-8ae22a8cbd28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "043461d9-ea4b-45f2-bdf8-0c428fbecdcf", "AQAAAAEAACcQAAAAEI+ccEDo5mUGIwoxVWN06nhC2jHHqGmJ0lYeomPTI+hWTIsMtLbbcSdTWDAJ1Nn/kg==", "e0f63b99-45ff-4c1e-a5bf-319af1b7f66c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 15, 11, 45, 208, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GameId",
                table: "Games_Media",
                column: "GameId",
                principalTable: "Games_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
