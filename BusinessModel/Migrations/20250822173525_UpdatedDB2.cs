using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Store_Wishlists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_ThreadUpvoteHistories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Store_Threads",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Store_ThreadReplyUpvoteHistories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Store_ThreadReplies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_RefundRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Cart",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3b421c13-ee47-44bc-863b-cea6018386f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "ef8a11da-b62d-46d2-879f-f566e3a859d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "24ac2c1d-b9ef-49f6-b3d5-f73e234fc273");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b62d3aad-e5b9-4585-9673-8d4d4c4a644d", "AQAAAAEAACcQAAAAEHAMkOpO5TCU2TbE+J0uTAXiZ356EzvObrtIOId2QMPNdjZoK/0oCmJvAWQQ4MLq3w==", "96c47d92-c494-4d3e-aeca-ed8cf4974b15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6504751b-ae52-4163-8625-b3ffc0c697d3", "AQAAAAEAACcQAAAAEP/OxOaJCXFelaoc2Q/PoMGtY24Ohg/tFXjAhpo54BoFxiOMlDoZAuUkcZGpH9yQkQ==", "4c98f29e-4810-448f-81e2-a7c7aae5a903" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecbd47b5-4470-4e02-9a20-e24ec76de54d", "AQAAAAEAACcQAAAAED6bo0vjNThlLjLS1oXaFLYiMXh6iqIN1UXgDEAqHBXSWRuUVLTtLIMrdoBJ9p++Ww==", "d5164302-77bf-4593-b572-ad1af0909c80" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 17, 35, 25, 435, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.CreateIndex(
                name: "IX_Store_Wishlists_UserId",
                table: "Store_Wishlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadUpvoteHistories_UserID",
                table: "Store_ThreadUpvoteHistories",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Threads_CreatedBy",
                table: "Store_Threads",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadReplyUpvoteHistories_UserId",
                table: "Store_ThreadReplyUpvoteHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadReplies_CreatedBy",
                table: "Store_ThreadReplies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Store_RefundRequests_UserID",
                table: "Store_RefundRequests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Orders_UserID",
                table: "Store_Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Cart_UserID",
                table: "Store_Cart",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Cart_AspNetUsers_UserID",
                table: "Store_Cart",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Orders_AspNetUsers_UserID",
                table: "Store_Orders",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_RefundRequests_AspNetUsers_UserID",
                table: "Store_RefundRequests",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_ThreadReplies_AspNetUsers_CreatedBy",
                table: "Store_ThreadReplies",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_ThreadReplyUpvoteHistories_AspNetUsers_UserId",
                table: "Store_ThreadReplyUpvoteHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Threads_AspNetUsers_CreatedBy",
                table: "Store_Threads",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_ThreadUpvoteHistories_AspNetUsers_UserID",
                table: "Store_ThreadUpvoteHistories",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Wishlists_AspNetUsers_UserId",
                table: "Store_Wishlists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Cart_AspNetUsers_UserID",
                table: "Store_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Orders_AspNetUsers_UserID",
                table: "Store_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_RefundRequests_AspNetUsers_UserID",
                table: "Store_RefundRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_ThreadReplies_AspNetUsers_CreatedBy",
                table: "Store_ThreadReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_ThreadReplyUpvoteHistories_AspNetUsers_UserId",
                table: "Store_ThreadReplyUpvoteHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Threads_AspNetUsers_CreatedBy",
                table: "Store_Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_ThreadUpvoteHistories_AspNetUsers_UserID",
                table: "Store_ThreadUpvoteHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Wishlists_AspNetUsers_UserId",
                table: "Store_Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Store_Wishlists_UserId",
                table: "Store_Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Store_ThreadUpvoteHistories_UserID",
                table: "Store_ThreadUpvoteHistories");

            migrationBuilder.DropIndex(
                name: "IX_Store_Threads_CreatedBy",
                table: "Store_Threads");

            migrationBuilder.DropIndex(
                name: "IX_Store_ThreadReplyUpvoteHistories_UserId",
                table: "Store_ThreadReplyUpvoteHistories");

            migrationBuilder.DropIndex(
                name: "IX_Store_ThreadReplies_CreatedBy",
                table: "Store_ThreadReplies");

            migrationBuilder.DropIndex(
                name: "IX_Store_RefundRequests_UserID",
                table: "Store_RefundRequests");

            migrationBuilder.DropIndex(
                name: "IX_Store_Orders_UserID",
                table: "Store_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Store_Cart_UserID",
                table: "Store_Cart");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Store_Wishlists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_ThreadUpvoteHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Store_Threads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Store_ThreadReplyUpvoteHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Store_ThreadReplies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_RefundRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Store_Cart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
        }
    }
}
