using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class FixedReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games_Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallerFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentGatewayResponse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store_Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store_Threads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreadImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpvoteCount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Threads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System_Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "System_Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_AspNetUsers_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositWithdrawTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositWithdrawTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositWithdrawTransactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "User_Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Wallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games_Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercent = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GamesInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Discount_Games_Info_GamesInfoId",
                        column: x => x.GamesInfoId,
                        principalTable: "Games_Info",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games_Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    MediaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Media_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games_Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUpvoted = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Reviews_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games_Uploads",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    GameVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Uploads", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Uploads_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_Cart_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_Library",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamesID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Library", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_Library_Games_Info_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Games_Info",
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

            migrationBuilder.CreateTable(
                name: "Store_OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_OrderDetails_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_OrderDetails_Store_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Store_Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_RefundRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_RefundRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_RefundRequests_Store_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Store_Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_Transactions_Store_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Store_Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_ThreadReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadID = table.Column<int>(type: "int", nullable: false),
                    ThreadComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpvoteCount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_ThreadReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_ThreadReplies_Store_Threads_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "Store_Threads",
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
                name: "Games_Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Categories_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Categories_System_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "System_Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games_Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Tags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Tags_Games_Info_GameID",
                        column: x => x.GameID,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Tags_System_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "System_Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games_InfoDiscounts",
                columns: table => new
                {
                    GamesInfoId = table.Column<int>(type: "int", nullable: false),
                    GamesDiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_InfoDiscounts", x => new { x.GamesInfoId, x.GamesDiscountId });
                    table.ForeignKey(
                        name: "FK_Games_InfoDiscounts_Games_Discount_GamesDiscountId",
                        column: x => x.GamesDiscountId,
                        principalTable: "Games_Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_InfoDiscounts_Games_Info_GamesInfoId",
                        column: x => x.GamesInfoId,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f6781b2-4564-4bb3-8d85-92e4c194a2cb", "c8d2f3c9-bd57-4944-b0a9-2b2ef8df1d6e", "Staff", "STAFF" },
                    { "26e5f054-e9fd-489f-891f-cf2b57fa9a1c", "c8064883-3f8d-4157-8b5d-37208f255acc", "User", "USER" },
                    { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "be98f8fb-1415-491c-81e1-4c5fc72ec1e2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af", 0, "9945265a-1744-4d33-8bdd-696d9f68e520", "admin@gameshop.com", true, false, null, "ADMIN@GAMESHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEM+ZWVlSR4u5T59cSODewo1R6OzprqmZIHUyISww0Gt72Aojb2SCNlWPo9Crr+yOtw==", null, false, "6f03d0de-2234-437b-a88e-3e48f223a424", false, "admin" },
                    { "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af", 0, "c3c88c9f-c08b-45a9-b0b6-d02f8d35a94b", "trananhtuan180202@gmail.com", true, false, null, "TRANANHTUAN180202@GMAIL.COM", "TRANANHTUAN180202", "AQAAAAEAACcQAAAAENK4PJ4cRVSQXy+BbbSKY9Uu5pd8kVjKxxOBjVRJvjZLp18VwXUG4IC5o93hVckv5A==", null, false, "a8316d1e-3f8e-468b-bcfd-83bdfa0e73ee", false, "trananhtuan180202" },
                    { "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af", 0, "a32364ac-1643-40e0-9bf5-ea1654e3c5ab", "phong260702@gmail.com", true, false, null, "PHONG260702@GMAIL.COM", "PHONG", "AQAAAAEAACcQAAAAEDeTheymrp1z8s4zQw9Ij7ivvUhpIPrl+w9qCBVKmp+6Qco/Qo2AEKz7dHkMRjjiXQ==", null, false, "f8cfd508-0ac5-422f-86f1-08fa407c2b25", false, "phong" }
                });

            migrationBuilder.InsertData(
                table: "System_Categories",
                columns: new[] { "ID", "CategoryName", "CreatedAt", "CreatedBy" },
                values: new object[,]
                {
                    { 1, "RPG", new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3718), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af" },
                    { 2, "FPS", new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3719), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af" },
                    { 3, "Puzzle", new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3721), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af" },
                    { 4, "Simulation", new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3722), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af" },
                    { 5, "Horror", new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3723), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af" }
                });

            migrationBuilder.InsertData(
                table: "System_Tags",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "TagName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3694), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af", "Action" },
                    { 2, new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3696), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af", "Adventure" },
                    { 3, new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3697), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af", "Multiplayer" },
                    { 4, new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3699), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af", "Indie" },
                    { 5, new DateTime(2025, 8, 12, 17, 21, 37, 102, DateTimeKind.Utc).AddTicks(3700), "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af", "Strategy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af" },
                    { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af" },
                    { "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11", "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ChangedByUserId",
                table: "ApprovalHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DepositWithdrawTransactions_UserId",
                table: "DepositWithdrawTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Categories_CategoryID",
                table: "Games_Categories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Categories_GameID",
                table: "Games_Categories",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Discount_GamesInfoId",
                table: "Games_Discount",
                column: "GamesInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_InfoDiscounts_GamesDiscountId",
                table: "Games_InfoDiscounts",
                column: "GamesDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Media_GameID",
                table: "Games_Media",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Reviews_GameID",
                table: "Games_Reviews",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Tags_GameID",
                table: "Games_Tags",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Tags_TagID",
                table: "Games_Tags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Uploads_GameID",
                table: "Games_Uploads",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Cart_GameID",
                table: "Store_Cart",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Library_GamesID",
                table: "Store_Library",
                column: "GamesID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_OrderDetails_GameID",
                table: "Store_OrderDetails",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_OrderDetails_OrderID",
                table: "Store_OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_RefundRequests_OrderID",
                table: "Store_RefundRequests",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadReplies_ThreadID",
                table: "Store_ThreadReplies",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadReplyUpvoteHistories_ThreadCommentId",
                table: "Store_ThreadReplyUpvoteHistories",
                column: "ThreadCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ThreadUpvoteHistories_ThreadID",
                table: "Store_ThreadUpvoteHistories",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Transactions_OrderID",
                table: "Store_Transactions",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Wishlists_GameId",
                table: "Store_Wishlists",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_System_ProfilePictures_UserId",
                table: "System_ProfilePictures",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Wallets_UserId",
                table: "User_Wallets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DepositWithdrawTransactions");

            migrationBuilder.DropTable(
                name: "Games_Banner");

            migrationBuilder.DropTable(
                name: "Games_Categories");

            migrationBuilder.DropTable(
                name: "Games_InfoDiscounts");

            migrationBuilder.DropTable(
                name: "Games_Media");

            migrationBuilder.DropTable(
                name: "Games_Reviews");

            migrationBuilder.DropTable(
                name: "Games_Tags");

            migrationBuilder.DropTable(
                name: "Games_Uploads");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "Store_Cart");

            migrationBuilder.DropTable(
                name: "Store_Library");

            migrationBuilder.DropTable(
                name: "Store_OrderDetails");

            migrationBuilder.DropTable(
                name: "Store_RefundRequests");

            migrationBuilder.DropTable(
                name: "Store_ThreadReplyUpvoteHistories");

            migrationBuilder.DropTable(
                name: "Store_ThreadUpvoteHistories");

            migrationBuilder.DropTable(
                name: "Store_Transactions");

            migrationBuilder.DropTable(
                name: "Store_Wishlists");

            migrationBuilder.DropTable(
                name: "System_ProfilePictures");

            migrationBuilder.DropTable(
                name: "User_Wallets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "System_Categories");

            migrationBuilder.DropTable(
                name: "Games_Discount");

            migrationBuilder.DropTable(
                name: "System_Tags");

            migrationBuilder.DropTable(
                name: "Store_ThreadReplies");

            migrationBuilder.DropTable(
                name: "Store_Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Games_Info");

            migrationBuilder.DropTable(
                name: "Store_Threads");
        }
    }
}
