using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class StatisticRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        // ✅ Helper for creating test games with all required fields
        private GamesInfo CreateTestGame(int id, string title, decimal price = 50m)
        {
            return new GamesInfo
            {
                Id = id,
                Title = title,
                Description = "Test description",
                Genre = "RPG",
                DeveloperId = "Dev1",
                Price = price,
                CoverImagePath = "cover.jpg",
                InstallerFilePath = "installer.exe",
                CreatedBy = "UnitTest"
            };
        }

        [Test]
        public async Task GetRevenueStatisticAsync_ShouldReturnTotalRevenue_AndOrders()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                // Arrange
                var order1 = new StoreOrder
                {
                    OrderCode = "ORD-T1",
                    OrderDate = new DateTime(2025, 1, 1),
                    UserID = "User1",
                    Status = "Success"
                };
                var order2 = new StoreOrder
                {
                    OrderCode = "ORD-T2",
                    OrderDate = new DateTime(2025, 1, 2),
                    UserID = "User2",
                    Status = "Success"
                };
                context.Store_Orders.AddRange(order1, order2);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = order1.ID, GameID = 101, UnitPrice = 50m },
                    new StoreOrderDetail { OrderID = order2.ID, GameID = 102, UnitPrice = 150m }
                );
                context.Games_Info.AddRange(
                    CreateTestGame(101, "Game A", 50m),
                    CreateTestGame(102, "Game B", 150m)
                );
                await context.SaveChangesAsync();

                var repo = new StatisticRepository(context);

                // Act
                var result = await repo.GetRevenueStatisticAsync(new RevenueStatisticRequestDTO
                {
                    From = new DateTime(2025, 1, 1),
                    To = new DateTime(2025, 1, 5)
                });

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(200m, result.TotalRevenue);
                Assert.AreEqual(2, result.TotalOrders);
                Assert.AreEqual(2, result.GameRevenues.Count);
                Assert.AreEqual(2, result.RevenueByDay.Count);
            }
        }

        [Test]
        public async Task GetRevenueStatisticAsync_ShouldFilterByUser()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Store_Orders.AddRange(
                    new StoreOrder { OrderCode = "ORD-U1", OrderDate = DateTime.UtcNow, UserID = "User1", Status = "Success" },
                    new StoreOrder { OrderCode = "ORD-U2", OrderDate = DateTime.UtcNow, UserID = "User2", Status = "Success" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StatisticRepository(context);

                // Act
                var result = await repo.GetRevenueStatisticAsync(new RevenueStatisticRequestDTO
                {
                    From = DateTime.UtcNow.AddDays(-1),
                    To = DateTime.UtcNow.AddDays(1),
                    UserId = "User1"
                });

                // Assert
                Assert.AreEqual(1, result.TotalOrders);
                Assert.AreEqual(1, result.TotalUsersPurchased);
            }
        }

        [Test]
        public async Task GetRevenueStatisticAsync_ShouldFilterByGame()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder { OrderCode = "ORD-G1", OrderDate = DateTime.UtcNow, UserID = "UserX", Status = "Success" };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = order.ID, GameID = 201, UnitPrice = 75m },
                    new StoreOrderDetail { OrderID = order.ID, GameID = 202, UnitPrice = 125m }
                );
                context.Games_Info.AddRange(
                    CreateTestGame(201, "Game X", 75m),
                    CreateTestGame(202, "Game Y", 125m)
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StatisticRepository(context);

                // Act
                var result = await repo.GetRevenueStatisticAsync(new RevenueStatisticRequestDTO
                {
                    From = DateTime.UtcNow.AddDays(-1),
                    To = DateTime.UtcNow.AddDays(1),
                    GameId = 201
                });

                // Assert
                Assert.AreEqual(75m, result.TotalRevenue);
                Assert.AreEqual(1, result.GameRevenues.Count);
                Assert.AreEqual("Game X", result.GameRevenues.First().GameName);
            }
        }

        [Test]
        public async Task GetRevenueStatisticAsync_ShouldCountRefunds()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder
                {
                    OrderCode = "ORD-R1",
                    OrderDate = DateTime.UtcNow,
                    UserID = "UserR",
                    Status = "Success"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.Add(new StoreOrderDetail
                {
                    OrderID = order.ID,
                    GameID = 301,
                    UnitPrice = 60m
                });
                context.Games_Info.Add(new GamesInfo
                {
                    Id = 301,
                    Title = "Refunded Game",
                    Description = "Test description",
                    Genre = "RPG",
                    DeveloperId = "Dev1",
                    Price = 60m,
                    CoverImagePath = "cover.jpg",
                    InstallerFilePath = "installer.exe",
                    CreatedBy = "UnitTest"
                });

                // ✅ Include required props
                context.Store_RefundRequests.Add(new StoreRefundRequest
                {
                    OrderID = order.ID,
                    Status = "APPROVED",
                    Reason = "Test refund",
                    UserID = "UserR"
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StatisticRepository(context);

                // Act
                var result = await repo.GetRevenueStatisticAsync(new RevenueStatisticRequestDTO
                {
                    From = DateTime.UtcNow.AddDays(-1),
                    To = DateTime.UtcNow.AddDays(1)
                });

                // Assert
                Assert.AreEqual(1, result.TotalRefunds);
            }
        }


        [Test]
        public async Task GetRevenueStatisticAsync_ShouldReturnTopSellingGames()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder { OrderCode = "ORD-TOP", OrderDate = DateTime.UtcNow, UserID = "UserTop", Status = "Success" };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = order.ID, GameID = 401, UnitPrice = 10m },
                    new StoreOrderDetail { OrderID = order.ID, GameID = 401, UnitPrice = 10m },
                    new StoreOrderDetail { OrderID = order.ID, GameID = 402, UnitPrice = 20m }
                );
                context.Games_Info.AddRange(
                    CreateTestGame(401, "Game Popular", 10m),
                    CreateTestGame(402, "Game Less Popular", 20m)
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StatisticRepository(context);

                // Act
                var result = await repo.GetRevenueStatisticAsync(new RevenueStatisticRequestDTO
                {
                    From = DateTime.UtcNow.AddDays(-1),
                    To = DateTime.UtcNow.AddDays(1),
                    TopNGame = 1
                });

                // Assert
                Assert.AreEqual(1, result.TopSellingGames.Count);
                Assert.AreEqual("Game Popular", result.TopSellingGames.First().GameName);
                Assert.AreEqual(2, result.TopSellingGames.First().SoldQuantity);
            }
        }
    }
}
