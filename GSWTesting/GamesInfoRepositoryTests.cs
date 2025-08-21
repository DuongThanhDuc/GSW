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
    public class GamesInfoRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewGame()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var dto = new GamesInfoDTO
            {
                Title = "Test Game",
                Description = "Test Description",
                Price = 9.99m,
                Genre = "Action",
                DeveloperId = "Dev1",
                InstallerFilePath = "installer.exe",
                CoverImagePath = "cover.png",
                Status = "Draft",
                IsActive = true,
                CreatedBy = "Tester"
            };

            using (var context = new DBContext(options))
            {
                var repo = new GamesInfoRepository(context);

                // Act
                var result = await repo.CreateAsync(dto);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("Test Game", result.Title);
                Assert.AreEqual(1, await context.Games_Info.CountAsync());
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int gameId;
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo
                {
                    Title = "Existing Game",
                    Description = "Some description",
                    Price = 19.99m,
                    Genre = "RPG",
                    DeveloperId = "Dev2",
                    InstallerFilePath = "install.exe",
                    CoverImagePath = "cover.jpg",
                    Status = "Published",
                    IsActive = true,
                    CreatedBy = "Admin"
                };
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();
                gameId = game.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesInfoRepository(context);

                // Act
                var result = await repo.GetByIdAsync(gameId);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("Existing Game", result.Title);
                Assert.AreEqual("RPG", result.Genre);
                Assert.AreEqual("Admin", result.CreatedBy);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int gameId;
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo
                {
                    Title = "Delete Me",
                    Description = "Temp",
                    Price = 1,
                    Genre = "Test",
                    DeveloperId = "Dev1",
                    InstallerFilePath = "delete_installer.exe",
                    CoverImagePath = "delete_cover.png",
                    Status = "Draft",
                    IsActive = true,
                    CreatedBy = "System"
                };
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();
                gameId = game.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesInfoRepository(context);

                // Act
                var result = await repo.DeleteAsync(gameId);

                // Assert
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Games_Info.CountAsync());
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllGames()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Info.AddRange(
                    new GamesInfo
                    {
                        Title = "Game 1",
                        Description = "D1",
                        Price = 2,
                        Genre = "Action",
                        DeveloperId = "Dev1",
                        InstallerFilePath = "g1_installer.exe",
                        CoverImagePath = "g1_cover.png",
                        Status = "Draft",
                        IsActive = true,
                        CreatedBy = "System"
                    },
                    new GamesInfo
                    {
                        Title = "Game 2",
                        Description = "D2",
                        Price = 3,
                        Genre = "RPG",
                        DeveloperId = "Dev2",
                        InstallerFilePath = "g2_installer.exe",
                        CoverImagePath = "g2_cover.png",
                        Status = "Published",
                        IsActive = true,
                        CreatedBy = "System"
                    }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesInfoRepository(context);

                // Act
                var result = await repo.GetAllAsync();

                // Assert
                Assert.AreEqual(2, result.Count());
            }
        }


        [Test]
        public async Task UpdateAsync_ShouldModifyExistingEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int gameId;
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo
                {
                    Title = "Old Title",
                    Description = "Old Desc",
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
                await context.SaveChangesAsync();
                gameId = game.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesInfoRepository(context);
                var updateDto = new GamesInfoDTO
                {
                    ID = gameId,
                    Title = "Updated Title",
                    Description = "New Desc",
                    Price = 10.0m,
                    Genre = "Adventure",
                    DeveloperId = "Dev3",
                    InstallerFilePath = "new_installer.exe",
                    CoverImagePath = "new_cover.png",
                    Status = "Published",
                    IsActive = true,
                    CreatedBy = "Updater"
                };

                // Act
                var result = await repo.UpdateAsync(updateDto);

                // Assert
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                var updated = await context.Games_Info.FindAsync(gameId);
                Assert.AreEqual("Updated Title", updated.Title);
                Assert.AreEqual("Adventure", updated.Genre);
                Assert.AreEqual("Updater", updated.CreatedBy);
            }
        }
    }
}
