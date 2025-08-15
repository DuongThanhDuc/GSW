using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTransactionsToStoreOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Transactions_Store_Orders_OrderID",
                table: "Store_Transactions");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentTransactions");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTransactionId",
                table: "Store_Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GatewayOrderId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreOrderId",
                table: "PaymentTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreTransactionID",
                table: "PaymentTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
                column: "ConcurrencyStamp",
                value: "c42d66a3-be56-4029-8a3e-0364e37269f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
                column: "ConcurrencyStamp",
                value: "03156ba6-da8b-466c-8497-ce0e0b8eeb25");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
                column: "ConcurrencyStamp",
                value: "5679e3bc-e912-4a90-989c-be35ae840018");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f01d45cb-716e-494c-a2bc-3282c12de769", "AQAAAAEAACcQAAAAEC+fZ7DI0IfXdo3OtiyjjjsVi8HXnQykUutdNHUBcSpW2vTMguBHI+6RLlcWu0LLAQ==", "bea2c666-f578-44ad-a8a5-36282a071fc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcdd33-9a99-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaca0ba2-3641-46a0-95ac-e7cf56bbff84", "AQAAAAEAACcQAAAAEEcVTa5SvLaJ79+eqhRJR0ZqkUsghnlMdVKsM1HWvPUuysOxrBJuhHuTQSWgEM1Z+Q==", "796fdd65-7c7b-497a-a4bf-bf25860de6e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcbcde35-9a98-75dv-82d7-0c9e67f9d9af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1809b18-7455-4551-948e-07c3e3b766b3", "AQAAAAEAACcQAAAAEAZApfEIE2XaQ6NBwzKRFE3efeYfQoVZHN1X2SvLKETzMlNBM/WOkkemEUKnW8zulw==", "374102d0-3eee-4baf-a94e-4dacfb4f9b7b" });

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "System_Categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "System_Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 7, 26, 42, 349, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.CreateIndex(
                name: "IX_Store_Transactions_PaymentTransactionId",
                table: "Store_Transactions",
                column: "PaymentTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_StoreOrderId",
                table: "PaymentTransactions",
                column: "StoreOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_StoreTransactionID",
                table: "PaymentTransactions",
                column: "StoreTransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_Store_Orders_StoreOrderId",
                table: "PaymentTransactions",
                column: "StoreOrderId",
                principalTable: "Store_Orders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_Store_Transactions_StoreTransactionID",
                table: "PaymentTransactions",
                column: "StoreTransactionID",
                principalTable: "Store_Transactions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Transactions_PaymentTransactions_PaymentTransactionId",
                table: "Store_Transactions",
                column: "PaymentTransactionId",
                principalTable: "PaymentTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Transactions_Store_Orders_OrderID",
                table: "Store_Transactions",
                column: "OrderID",
                principalTable: "Store_Orders",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Store_Orders_StoreOrderId",
                table: "PaymentTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Store_Transactions_StoreTransactionID",
                table: "PaymentTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Transactions_PaymentTransactions_PaymentTransactionId",
                table: "Store_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Transactions_Store_Orders_OrderID",
                table: "Store_Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Store_Transactions_PaymentTransactionId",
                table: "Store_Transactions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransactions_StoreOrderId",
                table: "PaymentTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransactions_StoreTransactionID",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "Store_Transactions");

            migrationBuilder.DropColumn(
                name: "GatewayOrderId",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "StoreOrderId",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "StoreTransactionID",
                table: "PaymentTransactions");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Transactions_Store_Orders_OrderID",
                table: "Store_Transactions",
                column: "OrderID",
                principalTable: "Store_Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
