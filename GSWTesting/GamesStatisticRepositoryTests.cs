using BusinessModel.Model;
using DataAccess.DTOs;
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
    public class GameStatisticRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task GetTopSellingGamesAsync_ShouldReturnTopSellingGames()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game1 = new GamesInfo
                     {
                         Title = "Game A",
                         Description = "Desc A",
                         Price = 5.0m,
                         Genre = "Puzzle",
                         DeveloperId = "Dev3",
                         InstallerFilePath = "old_installer.exe",
                         CoverImagePath = "old_cover.png",
                         Status = "Draft",
                         IsActive = false,
                         CreatedBy = "Tester"
                     };
                var game2 = new GamesInfo
                {
                    Title = "Game B",
                    Description = "Desc B",
                    Price = 5.0m,
                    Genre = "Puzzle",
                    DeveloperId = "Dev3",
                    InstallerFilePath = "old_installer.exe",
                    CoverImagePath = "old_cover.png",
                    Status = "Draft",
                    IsActive = false,
                    CreatedBy = "Tester"
                };
                context.Games_Info.AddRange(game1, game2);

                var order = new StoreOrder { OrderCode = "10", OrderDate = DateTime.Now, Status = "COMPLETED" };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = order.ID, GameID = game1.Id, UnitPrice = 50 },
                    new StoreOrderDetail { OrderID = order.ID, GameID = game1.Id, UnitPrice = 50 },
                    new StoreOrderDetail { OrderID = order.ID, GameID = game2.Id, UnitPrice = 40 }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GameStatisticRepository(context);
                var result = await repo.GetTopSellingGamesAsync(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), 2);

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("Game A", result.First().GameTitle);
                Assert.AreEqual(2, result.First().SoldQuantity);
                Assert.AreEqual(100, result.First().TotalRevenue);
            }
        }

        [Test]
        public async Task GetTopSellingGamesAsync_ShouldReturnEmpty_WhenNoCompletedOrders()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo
                {
                    Title = "Game A",
                    Description = "Desc A",
                    Price = 5.0m,
                    Genre = "Puzzle",
                    DeveloperId = "Dev3",
                    InstallerFilePath = "old_installer.exe",
                    CoverImagePath = "old_cover.png",
                    Status = "Draft",
                    IsActive = false,
                    CreatedBy = "Tester"
                };
                context.Games_Info.Add(game);

                var order = new StoreOrder { OrderCode = "Order 3", OrderDate = DateTime.Now, Status = "PENDING" };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.Add(new StoreOrderDetail { OrderID = order.ID, GameID = game.Id, UnitPrice = 60 });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GameStatisticRepository(context);
                var result = await repo.GetTopSellingGamesAsync(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), 5);

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Count);
            }
        }

        [Test]
        public async Task GetTopSellingGamesAsync_WithFilters_ShouldReturnFilteredGames()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game1 = new GamesInfo
                {
                    Title = "Game A",
                    Description = "Desc A",
                    Price = 5.0m,
                    Genre = "RPG",              // ✅ Matches filter
                    DeveloperId = "Dev3",
                    InstallerFilePath = "installer.exe",
                    CoverImagePath = "cover.png",
                    Status = "Active",          // ✅ Matches filter
                    IsActive = true,            // ✅ Matches filter
                    CreatedBy = "Tester"
                };

                var game2 = new GamesInfo
                {
                    Title = "Game B",
                    Description = "Desc B",
                    Price = 5.0m,
                    Genre = "Puzzle",           // ❌ Won’t match "RPG"
                    DeveloperId = "Dev3",
                    InstallerFilePath = "installer.exe",
                    CoverImagePath = "cover.png",
                    Status = "Draft",           // ❌ Won’t match "Active"
                    IsActive = false,           // ❌ Won’t match filter
                    CreatedBy = "Tester"
                };

                context.Games_Info.AddRange(game1, game2);

                var order = new StoreOrder
                {
                    OrderCode = "Order 1",
                    OrderDate = DateTime.Now,
                    Status = "COMPLETED"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = order.ID, GameID = game1.Id, UnitPrice = 70 },
                    new StoreOrderDetail { OrderID = order.ID, GameID = game2.Id, UnitPrice = 80 }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GameStatisticRepository(context);
                var req = new TopSellingGameRequestDTO
                {
                    From = DateTime.Now.AddDays(-1),
                    To = DateTime.Now.AddDays(1),
                    Genre = "RPG",
                    Status = "Active",
                    Page = 1,
                    PageSize = 10
                };

                var result = await repo.GetTopSellingGamesAsync(req);

                Assert.AreEqual(1, result.TotalRecords);
                Assert.AreEqual("Game A", result.Games.First().GameTitle);
                Assert.AreEqual("RPG", result.Games.First().Genre);
                Assert.AreEqual("Active", result.Games.First().Status);
            }
        }


        [Test]
        public async Task GetTopSellingGamesAsync_WithPaging_ShouldReturnCorrectPage()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game1 = new GamesInfo
                {
                    Title = "Game A",
                    Description = "Desc A",
                    Price = 5.0m,
                    Genre = "Puzzle",
                    DeveloperId = "Dev3",
                    InstallerFilePath = "old_installer.exe",
                    CoverImagePath = "old_cover.png",
                    Status = "Draft",
                    IsActive = false,
                    CreatedBy = "Tester"
                };
                var game2 = new GamesInfo
                {
                    Title = "Game B",
                    Description = "Desc B",
                    Price = 5.0m,
                    Genre = "Puzzle",
                    DeveloperId = "Dev3",
                    InstallerFilePath = "old_installer.exe",
                    CoverImagePath = "old_cover.png",
                    Status = "Draft",
                    IsActive = false,
                    CreatedBy = "Tester"
                };
                var game3 = new GamesInfo
                {
                    Title = "Game C",
                    Description = "Desc C",
                    Price = 5.0m,
                    Genre = "Puzzle",
                    DeveloperId = "Dev3",
                    InstallerFilePath = "old_installer.exe",
                    CoverImagePath = "old_cover.png",
                    Status = "Draft",
                    IsActive = false,
                    CreatedBy = "Tester"
                };
                context.Games_Info.AddRange(game1, game2, game3);

                var order = new StoreOrder { OrderCode = "Order 3", OrderDate = DateTime.Now, Status = "COMPLETED" };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = order.ID, GameID = game1.Id, UnitPrice = 30 },
                    new StoreOrderDetail { OrderID = order.ID, GameID = game2.Id, UnitPrice = 40 },
                    new StoreOrderDetail { OrderID = order.ID, GameID = game3.Id, UnitPrice = 50 }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GameStatisticRepository(context);
                var req = new TopSellingGameRequestDTO
                {
                    From = DateTime.Now.AddDays(-1),
                    To = DateTime.Now.AddDays(1),
                    Page = 2,
                    PageSize = 1
                };

                var result = await repo.GetTopSellingGamesAsync(req);

                Assert.AreEqual(3, result.TotalRecords);
                Assert.AreEqual(3, result.TotalPages);
                Assert.AreEqual(1, result.Games.Count);
                Assert.AreEqual(2, result.Page);
            }
        }
    }
}
