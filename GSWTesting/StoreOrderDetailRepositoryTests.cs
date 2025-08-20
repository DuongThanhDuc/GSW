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
    public class StoreOrderDetailRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewOrderDetail()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo { Title = "Test Game", Description="String", Price = 9.99m, Genre = "Action", DeveloperId = "Dev1",
                    InstallerFilePath = "setup.exe", CoverImagePath = "cover.jpg", IsActive = true, CreatedBy = "Tester" };
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();

                var repo = new StoreOrderDetailRepository(context);
                var dto = new StoreOrderDetailDTO { OrderID = 1, GameID = game.Id, UnitPrice = 9.99m, CreatedAt = DateTime.UtcNow };

                var result = await repo.CreateAsync(dto);

                Assert.NotNull(result);
                Assert.AreEqual(1, await context.Store_OrderDetails.CountAsync());
                Assert.AreEqual(dto.UnitPrice, result.UnitPrice);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
        {
            var options = CreateNewContextOptions();
            int detailId;
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo { Title = "Existing Game", Description = "String", Price = 19.99m, Genre = "RPG", DeveloperId = "Dev2", 
                    InstallerFilePath = "install.exe", CoverImagePath = "cover.jpg", IsActive = true, CreatedBy = "Admin" };
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();

                var detail = new StoreOrderDetail { OrderID = 1, GameID = game.Id, UnitPrice = 19.99m, CreatedAt = DateTime.UtcNow };
                context.Store_OrderDetails.Add(detail);
                await context.SaveChangesAsync();
                detailId = detail.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var result = await repo.GetByIdAsync(detailId);

                Assert.NotNull(result);
                Assert.AreEqual(detailId, result.ID);
                Assert.AreEqual("Existing Game", result.GameName);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var result = await repo.GetByIdAsync(999);

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingEntity()
        {
            var options = CreateNewContextOptions();
            int detailId;
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo { Title = "GameToUpdate", Description = "Initial description", Price = 5m, Genre = "Shooter", DeveloperId = "Dev3",
                    InstallerFilePath = "setup.exe", CoverImagePath = "cover.jpg", IsActive = true, CreatedBy = "Updater" };
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();

                var detail = new StoreOrderDetail { OrderID = 1, GameID = game.Id, UnitPrice = 5m, CreatedAt = DateTime.UtcNow };
                context.Store_OrderDetails.Add(detail);
                await context.SaveChangesAsync();
                detailId = detail.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var dto = new StoreOrderDetailDTO { OrderID = 2, GameID = 1, UnitPrice = 20m, CreatedAt = DateTime.UtcNow.AddDays(-1) };

                var result = await repo.UpdateAsync(detailId, dto);

                Assert.IsTrue(result);
                var updated = await context.Store_OrderDetails.FindAsync(detailId);
                Assert.AreEqual(20m, updated.UnitPrice);
                Assert.AreEqual(2, updated.OrderID);
            }
        }

        [Test]
        public async Task UpdateAsync_WhenEntityDoesNotExist_ShouldReturnFalse()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var dto = new StoreOrderDetailDTO { OrderID = 99, GameID = 1, UnitPrice = 100m, CreatedAt = DateTime.UtcNow };

                var result = await repo.UpdateAsync(999, dto);

                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveEntity()
        {
            var options = CreateNewContextOptions();
            int detailId;
            using (var context = new DBContext(options))
            {
                var detail = new StoreOrderDetail { OrderID = 3, GameID = 1, UnitPrice = 10m, CreatedAt = DateTime.UtcNow };
                context.Store_OrderDetails.Add(detail);
                await context.SaveChangesAsync();
                detailId = detail.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var result = await repo.DeleteAsync(detailId);

                Assert.IsTrue(result);
                Assert.AreEqual(0, await context.Store_OrderDetails.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_WhenEntityDoesNotExist_ShouldReturnFalse()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var result = await repo.DeleteAsync(999);

                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllOrderDetails()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game1 = new GamesInfo { Title = "Test Game1", Description = "String1", Price = 10m, Genre = "Action", DeveloperId = "Dev1", 
                    InstallerFilePath = "setup.exe", CoverImagePath = "cover1.jpg", IsActive = true, CreatedBy = "Admin" };
                var game2 = new GamesInfo { Title = "Test Game2", Description = "String2", Price = 10m, Genre = "Action", DeveloperId = "Dev2", 
                    InstallerFilePath = "setup2.exe", CoverImagePath = "cover2.jpg", IsActive = true, CreatedBy = "Admin" };
                context.Games_Info.AddRange(game1, game2);
                await context.SaveChangesAsync();

                context.Store_OrderDetails.AddRange(
                    new StoreOrderDetail { OrderID = 1, GameID = game1.Id, UnitPrice = 10m, CreatedAt = DateTime.UtcNow },
                    new StoreOrderDetail { OrderID = 2, GameID = game2.Id, UnitPrice = 20m, CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var result = (await repo.GetAllAsync()).ToList();

                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.Any(r => r.GameName == "Test Game1"));
                Assert.IsTrue(result.Any(r => r.GameName == "Test Game2"));
            }
        }

        [Test]
        public async Task GetAllAsync_WhenNoEntitiesExist_ShouldReturnEmptyList()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderDetailRepository(context);
                var result = (await repo.GetAllAsync()).ToList();

                Assert.NotNull(result);
                Assert.AreEqual(0, result.Count);
            }
        }
    }
}
