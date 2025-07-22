using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "System_ProfilePictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_ProfilePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_System_ProfilePictures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "2b0e44fa-d1fe-4915-a207-0bc22182715a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "a66b92e6-05a1-490a-a1c2-02f3cbdd48b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "d21ff49a-f35d-4b82-983f-0df30a25cfbf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96d49a34-30cf-4695-8bc1-76aa52b7e4b7", "AQAAAAEAACcQAAAAEJPgtLV0HRCZJwtini9F25JJ25L1nBMsRDN9hFsWII4qPSbQPApJfnk8vDf7wF7QrA==", "624299ec-5595-4e2b-b7d3-e1a850f5157b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f7c19b3-072c-4a70-a27f-7b18b6b7feef", "AQAAAAEAACcQAAAAEBAj1G1kS6VfYjgXQfEJAMws/ClgptTAGdqQlooLguTMbLToBSgtQiPi8jM8EvHncg==", "9a401568-72c6-4e39-a36d-d39048bda0af" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 6, 38, 9, 644, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.CreateIndex(
                name: "IX_System_ProfilePictures_UserId",
                table: "System_ProfilePictures",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "System_ProfilePictures");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "3f66102e-8bf4-4ba4-bae0-6218f3ebfa87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "5097e288-cabe-4aec-8dc1-86f053f79c1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "1aef5b7c-769e-4a91-8a17-1b74153ee0f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "415a37de-e267-4acc-b9de-959b6270901f", "AQAAAAEAACcQAAAAECmiy2DPmEoZJ2/pwvmkXtMHW7qYAbP5kK8XWuwxOrxWN51Rwpa6RP1MquLV1CNwkw==", "7b82f9b5-e254-439e-8210-46026be717f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d294fa9-89fa-40d1-9b8a-1f4f5f4099b4", "AQAAAAEAACcQAAAAEP8uvmC4vJCOSQqFvGDC5w9l0VX/V4YL2ce2QpQuHDLEL5LuQroGEbYKVQd47KFmEQ==", "b973767b-5260-474c-9f9c-cabd664dff85" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 12, 40, 46, 8, DateTimeKind.Utc).AddTicks(1196));
        }
    }
}
