using BusinessModel.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class GamesCategoryRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // isolation per test
                .Options;
        }

        [Test]
        public async Task GetAllAsync_WhenCalled_ShouldReturnAllGameCategories()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game1 = new GamesInfo
                {
                    Id = 101,
                    Title = "Game A",
                    CreatedBy = "Admin",
                    Description = "Test Desc",
                    Genre = "Action",
                    DeveloperId = "Dev1",
                    InstallerFilePath = "installer1.exe",
                    CoverImagePath = "cover1.png"
                };

                var game2 = new GamesInfo
                {
                    Id = 102,
                    Title = "Game B",
                    CreatedBy = "Admin",
                    Description = "Test Desc",
                    Genre = "Adventure",
                    DeveloperId = "Dev2",
                    InstallerFilePath = "installer2.exe",
                    CoverImagePath = "cover2.png"
                };


                var category1 = new SystemCategory { ID = 201, CategoryName = "Action", CreatedBy = "Admin" };
                var category2 = new SystemCategory { ID = 202, CategoryName = "Adventure", CreatedBy = "Admin" };

                context.Games_Info.AddRange(game1, game2);
                context.System_Categories.AddRange(category1, category2);

                context.Games_Categories.AddRange(
                    new GamesCategory { ID = 1, GameID = game1.Id, CategoryID = category1.ID, CreatedBy = "Admin" },
                    new GamesCategory { ID = 2, GameID = game2.Id, CategoryID = category2.ID, CreatedBy = "Admin" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesCategoryRepository(context);

                // Act
                var results = await repo.GetAllAsync();

                // Assert
                Assert.AreEqual(2, results.Count());
            }
        }
        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo
                {
                    Id = 101,
                    Title = "Game A",
                    CreatedBy = "Admin",
                    Description = "Test game",
                    Genre = "Action",
                    DeveloperId = "Dev1",
                    InstallerFilePath = "installer.exe",
                    CoverImagePath = "cover.png"
                };

                var category = new SystemCategory
                {
                    ID = 201,
                    CategoryName = "Action",
                    CreatedBy = "Admin"
                };

                context.Games_Info.Add(game);
                context.System_Categories.Add(category);

                context.Games_Categories.Add(new GamesCategory
                {
                    ID = 1,
                    GameID = game.Id,
                    CategoryID = category.ID,
                    CreatedBy = "UserX"
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesCategoryRepository(context);

                // Act
                var result = await repo.GetByIdAsync(1);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(101, result.GameID);
                Assert.AreEqual(201, result.CategoryID);
                Assert.AreEqual("UserX", result.CreatedBy);
            }
        }


        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new GamesCategoryRepository(context);

            // Act
            var result = await repo.GetByIdAsync(999);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddAsync_ShouldInsertNewEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new GamesCategoryRepository(context);

            var entity = new GamesCategory { ID = 1, GameID = 101, CategoryID = 201, CreatedBy = "Admin" };

            // Act
            var result = await repo.AddAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, await context.Games_Categories.CountAsync());
        }

        [Test]
        public async Task UpdateAsync_WhenEntityExists_ShouldUpdateAndReturnEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Categories.Add(new GamesCategory { ID = 1, GameID = 101, CategoryID = 201, CreatedBy = "Admin" });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesCategoryRepository(context);
                var updatedEntity = new GamesCategory { GameID = 202, CategoryID = 303, CreatedBy = "Moderator" };

                // Act
                var result = await repo.UpdateAsync(1, updatedEntity);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(202, result.GameID);
                Assert.AreEqual(303, result.CategoryID);
                Assert.AreEqual("Moderator", result.CreatedBy);
            }
        }

        [Test]
        public async Task UpdateAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new GamesCategoryRepository(context);

            var entity = new GamesCategory { GameID = 101, CategoryID = 201, CreatedBy = "Admin" };

            // Act
            var result = await repo.UpdateAsync(999, entity);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteAsync_WhenEntityExists_ShouldRemoveAndReturnTrue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Categories.Add(new GamesCategory { ID = 1, GameID = 101, CategoryID = 201, CreatedBy = "Admin" });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesCategoryRepository(context);

                // Act
                var result = await repo.DeleteAsync(1);

                // Assert
                Assert.IsTrue(result);
                Assert.AreEqual(0, await context.Games_Categories.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_WhenEntityDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new GamesCategoryRepository(context);

            // Act
            var result = await repo.DeleteAsync(999);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
