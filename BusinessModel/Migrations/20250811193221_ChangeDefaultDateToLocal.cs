using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDefaultDateToLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DepositWithdrawTransactions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "a3ab3f12-2580-489d-aaea-308ac9885bb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "5d614447-88c3-41de-83a1-4b5ded7de647");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "8488b659-8081-4523-981e-aa6621d06c4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4da81dec-f7d3-4e36-989b-e0c6cd52d401", "AQAAAAEAACcQAAAAEHPF86K16HKEoD9iwu8Pv8aMUh8Uflo8Cyzskv2Vq2urzOXtg07macU+Vfm4pKHV2g==", "40f6dce0-a37d-4aea-8cc6-0562c1652618" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cd90e3b-2013-4896-a271-6dcc83f07b2f", "AQAAAAEAACcQAAAAEN6j+guNygd/3V2RabvBOMFg2LkY45t7I7xuJ0+jaD5RxL6hfg/xdugdyqf17S0ygg==", "e4f21625-a14b-4344-a6f1-81860c5e9fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbbeed5e-560a-4ba7-b51e-7592c0004218", "AQAAAAEAACcQAAAAEJU4QMh9OPBzFNJpDKMVHeCjGq/R01G3YHd64XjmqS/xtZDl8nasYAaNkThe6lwLWA==", "97ffa362-e70e-4daa-9343-9d519ed18f81" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 19, 32, 21, 120, DateTimeKind.Utc).AddTicks(8095));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DepositWithdrawTransactions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

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
        }
    }
}
