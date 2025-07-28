using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class MediaType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaType",
                table: "Games_Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "b0c2a5dc-69bc-4e20-9abb-e12aae37a72b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "36198b2f-e076-4e4b-a65e-50155a60d556");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "c417e837-7437-4066-907d-c9b22a07d9f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c5fa994-00ac-4ee3-b853-170b26b966fe", "AQAAAAEAACcQAAAAEG/tvvR+CoI4ACOdcNYZRd73r4YHEZSjO7i4TtIcTNVsOL6+4sHEWOBQcB096VsSLQ==", "37d782f1-5251-41a1-aa38-63f965f213d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dee49eee-98a1-4645-822d-fbd2083e47fa", "AQAAAAEAACcQAAAAEIaRRBlvnuFNG+wuSwXezN4t4DcFzFO0taiwdCFJ5edlQ/S3t+wq9IRbvubRTqus0g==", "2f92eb64-ddc7-42c1-9072-0ec9cf75f7b2" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 28, 15, 50, 22, 626, DateTimeKind.Utc).AddTicks(9814));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Games_Media");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "675f3a30-44ee-48ec-aaed-755f7a4f1234");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "03e94273-7e37-45c4-acb9-21802b121f0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "419a31cb-72d9-4493-86e4-77dff9cec94c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95c41989-046b-4933-9403-bdce317d66a3", "AQAAAAEAACcQAAAAEDaxsIw26lrsdNe4hlo52r4V9ESgANaQZrDbYRtbt0Hu/3XJLmwOBUeQ9YDZJYyt2A==", "8118da5f-11d3-4bb5-a4aa-5afd8a51ba05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9dd2108-49d9-4f88-aadc-dd1c4e6e41f5", "AQAAAAEAACcQAAAAEM6VCBOY1VGedA/M06WdnTpFUUTnlMIzc+zJBjx2mX/CWRfdf3fhqJI88PAV2b6+mQ==", "c71153b2-7c5e-400a-8b9d-81f27b08d533" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 9, 30, 59, 675, DateTimeKind.Utc).AddTicks(3067));
        }
    }
}
