using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnnointationsPatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Games_Info",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "90793a68-a050-4837-a902-76508d3a29fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "7a67340c-1a42-41b5-b004-6a98aed24baa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "9a95188b-d5e5-480d-899d-7e65902b27a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899906da-099d-4a42-9e35-c40161a214fb", "AQAAAAEAACcQAAAAEDKrnNqS8OFtpzgZF41lfkAs+TDe5t6Xnuvvq7NxzmsHRqOC/eQEhA2uQEAcg+6TTg==", "a3a7612a-0ecd-4b6f-91e7-a0b07bb4ed48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e2bbb5f-52df-40df-b7e4-3b45fb76ca52", "AQAAAAEAACcQAAAAEEgRkRgpdZFyl2DFxTnOTdNooP3qZq+ZsdAgb1Ddaiqy3ZMyjNjOL4jabdeeunw42Q==", "a2099c47-a37f-4b8a-8153-230f73df6b89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dadeef75-3bf0-47d8-96df-8b84efe5224c", "AQAAAAEAACcQAAAAEG+f26hnrRxwQOM5umsgbEk2t0eqJU5MddElVt2kswhFIB4CfID9+/UOTRPMLdbcNg==", "6260064f-260c-4d5a-8a0c-cada88d24f8c" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 56, 50, 658, DateTimeKind.Utc).AddTicks(7854));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Games_Info",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "c32a6609-b2f4-4b03-b13d-58c98aaa546b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "a1921685-3cc1-4f1e-b46b-e45f3ad7a057");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "a222c9f4-b9c1-4431-aa4b-01734c36af39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63ee7236-f15f-4a90-aa07-1d14531d79e0", "AQAAAAEAACcQAAAAEOvv5VROLyzBp/R0P/SQeyEEWTpH8GndIy1sKchm4l7X6v1d/X6DsgcNAdPYPUS+1g==", "edeb35ab-d700-427d-a8e5-3380555623d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3de1e6ba-2a89-401d-8111-d96c1696c493", "AQAAAAEAACcQAAAAELaoBWttQpS2139dtqN6H4pVnKrwFBSdzwPz/78y0GvJcnESZNd+mELQvI6IMpbldw==", "2dca94fc-0202-4360-b2df-63ec69473ba0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2b2e66a-f704-4d45-a083-95453e59fcbe", "AQAAAAEAACcQAAAAEAx1SE9SOARKHKWqxeojVAIkSMtrxm4hk6NUb5PCtXIN/iE/zC3O1W6dBg7i4CP0Rg==", "ca9d8651-0bc7-47d1-a974-19cdd011bb50" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 12, 53, 28, 555, DateTimeKind.Utc).AddTicks(2646));
        }
    }
}
