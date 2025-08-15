using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class UpvoteWishlist2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThreadImageUrl",
                table: "Store_Threads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentImageUrl",
                table: "Store_ThreadReplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Store_ThreadReplyUpvoteHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadCommentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_ThreadReplyUpvoteHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_ThreadReplyUpvoteHistories_Store_ThreadReplies_ThreadCommentId",
                        column: x => x.ThreadCommentId,
                        principalTable: "Store_ThreadReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_ThreadUpvoteHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_ThreadUpvoteHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_ThreadUpvoteHistories_Store_Threads_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "Store_Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Wishlists_Games_Info_GameId",
                        column: x => x.GameId,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "7b75142a-ff79-4650-a4d9-ec6c81bae0ee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "98042911-812e-4400-896c-629254017592");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "03384d7e-ebab-4769-a051-164dcdce8b3e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19a0533f-81e5-4ebe-af0e-fe20892a45e1", "AQAAAAEAACcQAAAAEBsufUAIwZHL9gI68sqbmQl0kNW59weO48LkYFqXKiFILzCj0Mwo3H8Lw/lZix/xDw==", "c00c93b9-27c5-4842-ac57-69eff7638db7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e77b5657-453f-4576-8645-fc031ead9c60", "AQAAAAEAACcQAAAAEOqbd/JUfBkAR91qyS2PZrHXe28kbUguKyW7bMJBEtO+kFC2ZjaI87kQ86QzqLM+eA==", "170b0724-1b7d-4bf9-9fa3-a3619c323e90" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 4, 10, 55, 34, 616, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadReplyUpvoteHistories_ThreadCommentId",
                table: "Store_ThreadReplyUpvoteHistories",
                column: "ThreadCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadUpvoteHistories_ThreadID",
                table: "Store_ThreadUpvoteHistories",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Wishlists_GameId",
                table: "Store_Wishlists",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store_ThreadReplyUpvoteHistories");

            migrationBuilder.DropTable(
                name: "Store_ThreadUpvoteHistories");

            migrationBuilder.DropTable(
                name: "Store_Wishlists");

            migrationBuilder.DropColumn(
                name: "ThreadImageUrl",
                table: "Store_Threads");

            migrationBuilder.DropColumn(
                name: "CommentImageUrl",
                table: "Store_ThreadReplies");

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
    }
}
