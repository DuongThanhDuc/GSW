using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixGamesDiscountRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Discount_Games_Info_GamesInfoID",
                table: "Games_Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoID",
                table: "Games_Media");

            migrationBuilder.RenameColumn(
                name: "GamesInfoID",
                table: "Games_Media",
                newName: "GamesInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Media_GamesInfoID",
                table: "Games_Media",
                newName: "IX_Games_Media_GamesInfoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Games_Info",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GamesInfoID",
                table: "Games_Discount",
                newName: "GamesInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Discount_GamesInfoID",
                table: "Games_Discount",
                newName: "IX_Games_Discount_GamesInfoId");

            migrationBuilder.AlterColumn<int>(
                name: "GamesDiscountId",
                table: "Games_InfoDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "GamesInfoId",
                table: "Games_InfoDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

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
                name: "FK_Games_Discount_Games_Info_GamesInfoId",
                table: "Games_Discount",
                column: "GamesInfoId",
                principalTable: "Games_Info",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoId",
                table: "Games_Media",
                column: "GamesInfoId",
                principalTable: "Games_Info",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Discount_Games_Info_GamesInfoId",
                table: "Games_Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoId",
                table: "Games_Media");

            migrationBuilder.RenameColumn(
                name: "GamesInfoId",
                table: "Games_Media",
                newName: "GamesInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Media_GamesInfoId",
                table: "Games_Media",
                newName: "IX_Games_Media_GamesInfoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Games_Info",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GamesInfoId",
                table: "Games_Discount",
                newName: "GamesInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Discount_GamesInfoId",
                table: "Games_Discount",
                newName: "IX_Games_Discount_GamesInfoID");

            migrationBuilder.AlterColumn<int>(
                name: "GamesDiscountId",
                table: "Games_InfoDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "GamesInfoId",
                table: "Games_InfoDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "ec55a87f-4fdb-438d-a566-8ab4aac6983c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "af98235c-72db-4555-8925-236cb97fc0d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "948f8a5e-8977-4db0-a3a5-0d8c1f742066");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "199e020f-6e7a-4220-af26-68af9c32eaca", "AQAAAAEAACcQAAAAEBNn1RhlW1WP3P9/yknU391kKnQ0uTmy8lv3IuEIS411vVjXwvj4cnqIC245jzx0Fw==", "3df2dc23-2176-4759-8876-fbf75dae966c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 5, 10, 32, 510, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Discount_Games_Info_GamesInfoID",
                table: "Games_Discount",
                column: "GamesInfoID",
                principalTable: "Games_Info",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Media_Games_Info_GamesInfoID",
                table: "Games_Media",
                column: "GamesInfoID",
                principalTable: "Games_Info",
                principalColumn: "ID");
        }
    }
}
