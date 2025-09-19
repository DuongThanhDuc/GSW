using BusinessModel.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class PaymentRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateProvisionalOrderAsync_ShouldCreateOrder_WhenNotExists()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new PaymentRepository(context);

                // Act
                var order = await repo.CreateProvisionalOrderAsync("ORD001", "User1", 100m);

                // Assert
                Assert.NotNull(order);
                Assert.AreEqual("ORD001", order.OrderCode);
                Assert.AreEqual("User1", order.UserID);
                Assert.AreEqual(100m, order.TotalAmount);
                Assert.AreEqual("Pending", order.Status);
                Assert.AreEqual(1, await context.Store_Orders.CountAsync());
            }
        }

        [Test]
        public async Task CreateProvisionalOrderAsync_ShouldUpdateBuyerInfo_WhenOrderExists()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Store_Orders.Add(new StoreOrder
                {
                    OrderCode = "ORD002",
                    UserID = "UserX",
                    TotalAmount = 50m,
                    Status = "Pending"
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new PaymentRepository(context);

                // Act
                var order = await repo.CreateProvisionalOrderAsync("ORD001", "User1", 100m);

                // Assert
                Assert.NotNull(order);
               
            }
        }

        [Test]
        public async Task CreateTransactionAsync_ShouldAddTransaction()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new PaymentRepository(context);
                var tx = new PaymentTransaction
                {
                    StoreOrderId = 1,
                    Amount = 200m,
                    PaymentMethod = "CreditCard",   
                    Status = "Pending",           
                    CreatedAt = DateTime.UtcNow
                };

                // Act
                var result = await repo.CreateTransactionAsync(tx);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(1, await context.PaymentTransactions.CountAsync());
            }
        }

        [Test]
        public async Task GetByOrderCodeAsync_ShouldReturnTransaction_WhenExists()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder { OrderCode = "ORD003", TotalAmount = 300m, Status = "Pending" };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.PaymentTransactions.Add(new PaymentTransaction
                {
                    StoreOrderId = order.ID,
                    Amount = 300m,
                    PaymentMethod = "CreditCard",
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new PaymentRepository(context);

                // Act
                var tx = await repo.GetByOrderCodeAsync("ORD003");

                // Assert
                Assert.NotNull(tx);
                Assert.AreEqual(300m, tx.Amount);
            }
        }

        [Test]
        public async Task UpdateOrderStatusByCodeAsync_ShouldUpdateStatus()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Store_Orders.Add(new StoreOrder
                {
                    OrderCode = "ORD004",
                    TotalAmount = 400m,
                    Status = "Pending"
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new PaymentRepository(context);

                // Act
                await repo.UpdateOrderStatusByCodeAsync("ORD004", "success");

                // Assert
                var order = await context.Store_Orders.FirstAsync(o => o.OrderCode == "ORD004");
                Assert.AreEqual("Success", order.Status);
            }
        }

        [Test]
        public async Task GrantGameToLibraryAsync_ShouldAddGamesToLibrary()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder
                {
                    OrderCode = "ORD005",
                    UserID = "User123",
                    TotalAmount = 500m,
                    Status = "Success"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.Add(new StoreOrderDetail { OrderID = order.ID, GameID = 101 });
                context.Store_OrderDetails.Add(new StoreOrderDetail { OrderID = order.ID, GameID = 102 });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new PaymentRepository(context);

                // Act
                await repo.GrantGameToLibraryAsync(5);

                // Assert
                var libs = await context.Store_Library.Where(l => l.UserID == "User123").ToListAsync();
                Assert.AreEqual(2, libs.Count);
                Assert.IsTrue(libs.Any(l => l.GamesID == 101));
                Assert.IsTrue(libs.Any(l => l.GamesID == 102));
            }
        }

    }
}
