using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixedReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarCount",
                table: "Games_Reviews");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpvoted",
                table: "Games_Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "938ac430-0607-4d48-96b1-d91e3aca3a54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "f1e2d34e-bb9f-4709-b9f4-d0b840e6d71a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "b36c7fd8-add6-48ab-977a-2ceb474691d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd7a4ceb-9c0f-42b0-b157-f96629f59b39", "AQAAAAEAACcQAAAAEOTywmm0k1JmzgWMPSDGAeV8GP/Ya0eHfrdVptugm10s6exCVThWpwI5ZKL4iKlbvA==", "96675e2a-ac2e-44c6-b3b7-36c47c8ecdd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c3931e6-9caf-40ad-a1c6-e8b2a0020b15", "AQAAAAEAACcQAAAAEL8AuglMcSkGCDWE/xnbAMpkPYuvGj6lTHZ16pq00sVZicbZYZ/xsE4N8rwmHqGt2Q==", "e5a748ab-3319-4e88-8a3d-4033352ac2b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "806d7492-213f-4c85-986f-b9dd76527234", "AQAAAAEAACcQAAAAEJqjYLjRAZlOTOaC1qbk8g4VtJH7R8CktUPsHW/eLTUXQ346bx0jRYlPNUOjLFwYKQ==", "21c538e0-6695-4700-aaa1-a6b384c001a8" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 3, 37, 49, 831, DateTimeKind.Utc).AddTicks(4171));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpvoted",
                table: "Games_Reviews");

            migrationBuilder.AddColumn<int>(
                name: "StarCount",
                table: "Games_Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
