using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "System_Tags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "System_Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Library",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Games_Tags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperId",
                table: "Games_Info",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Games_Info",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Games_Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "610b797b-e5a1-4664-8c3c-c501dde9f3b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "1a0f87a8-ff22-40ad-bd6f-ce6b6a4a0596");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "14b276b8-98a2-4c81-8e82-378f6f81cceb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e2f409-529d-4dd3-945e-b72ab0a2f122", "AQAAAAEAACcQAAAAEFNiICpIcD56htW8Lom27jjAmZAM/YymP5dAL3XHu5PSeW6AKBmQBm5noj3pxIkZfQ==", "9160fd20-dcbb-409f-b954-c2de547cce96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "298100a1-dfe6-43fb-bcf2-2c3444412938", "AQAAAAEAACcQAAAAEAA50OVooneU9JGl8BPkXKVpPFi5mAHRAL1r7iMQnpFcqvCu2lnHk7H7+F+bgIFe2w==", "873b33d6-71c0-4cf4-bad2-68d20d57e060" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68326dfc-a000-4028-81c8-3a267ad79114", "AQAAAAEAACcQAAAAEGButAtfK0Mxe1zKrni33gCnrXFD93M9TwAMBmnmh2oLs+rWj+Q3L0Cd5XxWCtY72g==", "6723851c-5cea-4b30-81c1-e13ea9247bd1" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 26, 3, 806, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.CreateIndex(
                name: "IX_System_Tags_CreatedBy",
                table: "System_Tags",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_System_Categories_CreatedBy",
                table: "System_Categories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Library_UserID",
                table: "Store_Library",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Tags_CreatedBy",
                table: "Games_Tags",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Info_CreatedBy",
                table: "Games_Info",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Info_DeveloperId",
                table: "Games_Info",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Categories_CreatedBy",
                table: "Games_Categories",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_AspNetUsers_CreatedBy",
                table: "Games_Categories",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Info_AspNetUsers_CreatedBy",
                table: "Games_Info",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Info_AspNetUsers_DeveloperId",
                table: "Games_Info",
                column: "DeveloperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Tags_AspNetUsers_CreatedBy",
                table: "Games_Tags",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Library_AspNetUsers_UserID",
                table: "Store_Library",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_System_Categories_AspNetUsers_CreatedBy",
                table: "System_Categories",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_System_Tags_AspNetUsers_CreatedBy",
                table: "System_Tags",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_AspNetUsers_CreatedBy",
                table: "Games_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Info_AspNetUsers_CreatedBy",
                table: "Games_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Info_AspNetUsers_DeveloperId",
                table: "Games_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Tags_AspNetUsers_CreatedBy",
                table: "Games_Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Library_AspNetUsers_UserID",
                table: "Store_Library");

            migrationBuilder.DropForeignKey(
                name: "FK_System_Categories_AspNetUsers_CreatedBy",
                table: "System_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_System_Tags_AspNetUsers_CreatedBy",
                table: "System_Tags");

            migrationBuilder.DropIndex(
                name: "IX_System_Tags_CreatedBy",
                table: "System_Tags");

            migrationBuilder.DropIndex(
                name: "IX_System_Categories_CreatedBy",
                table: "System_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Store_Library_UserID",
                table: "Store_Library");

            migrationBuilder.DropIndex(
                name: "IX_Games_Tags_CreatedBy",
                table: "Games_Tags");

            migrationBuilder.DropIndex(
                name: "IX_Games_Info_CreatedBy",
                table: "Games_Info");

            migrationBuilder.DropIndex(
                name: "IX_Games_Info_DeveloperId",
                table: "Games_Info");

            migrationBuilder.DropIndex(
                name: "IX_Games_Categories_CreatedBy",
                table: "Games_Categories");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "System_Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "System_Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Library",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Games_Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperId",
                table: "Games_Info",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Games_Info",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Games_Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "4dfb923a-38ea-4abb-9503-8ed80b366677");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "f1890529-adf0-4d45-9a21-919e7df4c9a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "5a47e355-5bbe-4a20-8bbd-2f0266ddfc5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d84694bd-2d43-4cc4-a6c1-f43d97f0bbd2", "AQAAAAEAACcQAAAAEAAnYc7agGhYXnQD/Uterlf/H5fze8HKziVSJiPUGAzyCo5OPfpQTl+Qf4q5/0lolQ==", "7e30c0c2-6316-4bff-b792-1e9e42be8549" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2afd5de-90c8-418f-aed1-746433a1bc1a", "AQAAAAEAACcQAAAAEAre3XySQfO4TSswkNZNayRPERMNJ+/x7i+6w38BhDgc4Yp/3+3Hs/eQgulNzTgarA==", "5508e9f4-488e-4243-bf6e-3bf9f6a3c6b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0480472-2510-4942-93d8-1463f14fed58", "AQAAAAEAACcQAAAAEAAXmbCQNpSdFxAWaYQxaT1QIm2tT7Vk0DetdrJoZ5yuHnV8uPODrv9QKWjYVA7+nQ==", "68a2326e-a0cf-4810-b8bf-107caaadc75a" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 55, 22, 997, DateTimeKind.Utc).AddTicks(7580));
        }
    }
}
