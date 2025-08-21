using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class StoreCartRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewCart()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                mockGamesRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(new GamesInfoDTOReadOnly
                    {
                        ID = 1,
                        Title = "Test Game",
                        Price = 50,
                        ActiveDiscounts = new List<GamesDiscountDTO>()
                    });

                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var dto = new CartDTO
                {
                    UserID = "User1",
                    GameID = 1,
                    AddedAt = DateTime.Now
                };

                var result = await repo.CreateAsync(dto);

                Assert.NotNull(result);
                Assert.AreEqual("User1", result.UserID);
                Assert.AreEqual(1, await context.Store_Cart.CountAsync());
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnCartView()
        {
            var options = CreateNewContextOptions();
            int cartId;
            using (var context = new DBContext(options))
            {
                var cart = new StoreCart
                {
                    UserID = "User1",
                    GameID = 1,
                    AddedAt = DateTime.Now
                };
                context.Store_Cart.Add(cart);
                await context.SaveChangesAsync();
                cartId = cart.ID;
            }

            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                mockGamesRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(new GamesInfoDTOReadOnly
                    {
                        ID = 1,
                        Title = "Test Game",
                        Price = 50,
                        ActiveDiscounts = new List<GamesDiscountDTO>()
                    });

                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var result = await repo.GetByIdAsync(cartId);

                Assert.NotNull(result);
                Assert.AreEqual("Test Game", result.GameName);
                Assert.AreEqual(50m, result.Price);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCarts()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Store_Cart.AddRange(
                    new StoreCart { UserID = "User1", GameID = 1, AddedAt = DateTime.Now },
                    new StoreCart { UserID = "User2", GameID = 2, AddedAt = DateTime.Now }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                mockGamesRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new GamesInfoDTOReadOnly { ID = 1, Title = "Game 1", Price = 20, ActiveDiscounts = new List<GamesDiscountDTO>() });
                mockGamesRepo.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(new GamesInfoDTOReadOnly { ID = 2, Title = "Game 2", Price = 30, ActiveDiscounts = new List<GamesDiscountDTO>() });

                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var result = await repo.GetAllAsync();

                Assert.AreEqual(2, result.Count());
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingCart()
        {
            var options = CreateNewContextOptions();
            int cartId;
            using (var context = new DBContext(options))
            {
                var cart = new StoreCart
                {
                    UserID = "OldUser",
                    GameID = 1,
                    AddedAt = DateTime.Now
                };
                context.Store_Cart.Add(cart);
                await context.SaveChangesAsync();
                cartId = cart.ID;
            }

            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var dto = new CartDTO
                {
                    ID = cartId,
                    UserID = "UpdatedUser",
                    GameID = 2,
                    AddedAt = DateTime.Now
                };

                var result = await repo.UpdateAsync(dto);

                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                var updated = await context.Store_Cart.FindAsync(cartId);
                Assert.AreEqual("UpdatedUser", updated.UserID);
                Assert.AreEqual(2, updated.GameID);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveCart()
        {
            var options = CreateNewContextOptions();
            int cartId;
            using (var context = new DBContext(options))
            {
                var cart = new StoreCart
                {
                    UserID = "DeleteUser",
                    GameID = 1,
                    AddedAt = DateTime.Now
                };
                context.Store_Cart.Add(cart);
                await context.SaveChangesAsync();
                cartId = cart.ID;
            }

            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var result = await repo.DeleteAsync(cartId);

                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Store_Cart.CountAsync());
            }
        }

        [Test]
        public void CreateAsync_ShouldThrow_WhenDtoIsNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                Assert.ThrowsAsync<NullReferenceException>(async () =>
                {
                    await repo.CreateAsync(null);
                });


            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var result = await repo.GetByIdAsync(999);

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldReturnFalse_WhenEntityDoesNotExist()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var dto = new CartDTO
                {
                    ID = 999,
                    UserID = "Ghost",
                    GameID = 3,
                    AddedAt = DateTime.Now
                };

                var result = await repo.UpdateAsync(dto);

                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldReturnFalse_WhenEntityDoesNotExist()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var mockGamesRepo = new Mock<IGamesInfoRepository>();
                var repo = new StoreCartRepository(context, mockGamesRepo.Object);

                var result = await repo.DeleteAsync(999);

                Assert.IsFalse(result);
            }
        }

    }
}
