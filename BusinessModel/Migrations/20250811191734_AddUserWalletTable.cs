using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddUserWalletTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWallet_AspNetUsers_UserId",
                table: "UserWallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWallet",
                table: "UserWallet");

            migrationBuilder.RenameTable(
                name: "UserWallet",
                newName: "User_Wallets");

            migrationBuilder.RenameIndex(
                name: "IX_UserWallet_UserId",
                table: "User_Wallets",
                newName: "IX_User_Wallets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Wallets",
                table: "User_Wallets",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "38f0612d-a59e-4432-bc0f-d392a62d06f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "ac15de78-23f1-4e75-b001-d02824d65f2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "10e8e74e-f16a-4ccb-b54c-ade6b8628c38");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5c67234-da33-4168-8ff0-684855e96bc1", "AQAAAAEAACcQAAAAEB3DR8+pxSIoEm6rnoa9Rm1iVXzQEeQixlksrf2NZZ5InVxwOOKVKL7cpCVd2MiK1A==", "6f8d749c-f704-4f38-ae2a-2074acb6b893" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df5a3265-d5f5-4b8e-a1e3-04f06dca00e7", "AQAAAAEAACcQAAAAEPSOWZMFECBPE++Fg9L5TJFys9llwNVuLo6Wzi6cf/N1OvRYYTJsSLDkcxg8ZSodWw==", "5e1bde05-9f48-4cc4-8fb9-3728badae751" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbd0e33c-f5b3-4ad6-b740-25592612045f", "AQAAAAEAACcQAAAAEEXr5Ih1pJ6KJHv+mFM+u1NS2dqIMLFcUDiSubeT201mJBswLlaWUQlFbvJoycTLSg==", "70b166a8-fb8c-4c64-bf1d-52e99800072b" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 17, 34, 115, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Wallets_AspNetUsers_UserId",
                table: "User_Wallets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Wallets_AspNetUsers_UserId",
                table: "User_Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Wallets",
                table: "User_Wallets");

            migrationBuilder.RenameTable(
                name: "User_Wallets",
                newName: "UserWallet");

            migrationBuilder.RenameIndex(
                name: "IX_User_Wallets_UserId",
                table: "UserWallet",
                newName: "IX_UserWallet_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWallet",
                table: "UserWallet",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "f3f8cb78-a7d6-49ff-af9a-7d38fc193b5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "f8c55efc-7524-418a-9e63-c4c22fd7c15b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "13022ceb-f987-43df-8855-e8435c3bd6d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c65bcb8-9e8e-4012-9479-198c444e470b", "AQAAAAEAACcQAAAAEOh/atTKG+zk/hRM9QqJ3QRYKlkg9tCLVjZk7SIcbItF+euElUVjTpxKEcoz3PNmkQ==", "64d7966b-2565-4862-9aa5-650f6de08cf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eac9e9ae-3648-498a-a432-455673fa892f", "AQAAAAEAACcQAAAAEDdj497NBt/elkNxJolSZ/u3+W8l3CcCApBlzSS/btO5qr32HcFWQN1AbjRWZjrLjA==", "2f718059-56f1-44fc-940d-e105fe62cfa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf37a26c-f802-4c0b-b017-0840e2ddee26", "AQAAAAEAACcQAAAAEAhFswUeJtwUjlPnbJER0zxOGnCIEoCrViUbnmJyQkKOqkE0PJuK8plBsrIEnclqNg==", "0b3bb0df-df31-448b-a9af-a70b21fd6998" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9621));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 14, 16, 847, DateTimeKind.Utc).AddTicks(9622));

            migrationBuilder.AddForeignKey(
                name: "FK_UserWallet_AspNetUsers_UserId",
                table: "UserWallet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
