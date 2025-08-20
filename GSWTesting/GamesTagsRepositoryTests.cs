using BusinessModel.Model;
using Repository.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class GamesTagRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewGamesTag()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesTagRepository(context);
                var tag = new GamesTag
                {
                    GameID = 1,
                    TagID = 10,
                    CreatedBy = "Tester"
                };

                // Act
                var result = await repo.AddAsync(tag);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(1, await context.Games_Tags.CountAsync());
                Assert.AreEqual("Tester", result.CreatedBy);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int tagId;
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
                    IsActive = true,
                    CreatedBy = "Admin"
                };
                var tag = new SystemTag
                {
                    ID = 10,
                    TagName = "Action",
                    CreatedBy = "System"
                };

                context.Games_Info.Add(game);
                context.System_Tags.Add(tag);

                var gamesTag = new GamesTag
                {
                    GameID = game.Id,
                    TagID = tag.ID,
                    CreatedBy = "Admin"
                };
                context.Games_Tags.Add(gamesTag);
                await context.SaveChangesAsync();

                tagId = gamesTag.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesTagRepository(context);

                // Act
                var result = await repo.GetByIdAsync(tagId);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(1, result.GameID);
                Assert.AreEqual(10, result.TagID);
                Assert.AreEqual("Admin", result.CreatedBy);
                Assert.NotNull(result.Game); // navigation property check
                Assert.NotNull(result.Tag);  // navigation property check
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveEntity()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int tagId;
            using (var context = new DBContext(options))
            {
                var tag = new GamesTag
                {
                    GameID = 3,
                    TagID = 30,
                    CreatedBy = "System"
                };
                context.Games_Tags.Add(tag);
                await context.SaveChangesAsync();
                tagId = tag.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesTagRepository(context);

                // Act
                var result = await repo.DeleteAsync(tagId);

                // Assert
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Games_Tags.CountAsync());
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllTags()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var game1 = new GamesInfo
                {
                    Title = "Game One",
                    Description = "First description",
                    Price = 19.99m,
                    Genre = "RPG",
                    DeveloperId = "Dev1",
                    InstallerFilePath = "install1.exe",
                    CoverImagePath = "cover1.jpg",
                    IsActive = true,
                    CreatedBy = "Admin"
                };
                var game2 = new GamesInfo
                {
                    Title = "Game Two",
                    Description = "Second description",
                    Price = 29.99m,
                    Genre = "Action",
                    DeveloperId = "Dev2",
                    InstallerFilePath = "install2.exe",
                    CoverImagePath = "cover2.jpg",
                    IsActive = true,
                    CreatedBy = "Admin"
                };
                var tag1 = new SystemTag { ID = 11, TagName = "Action", CreatedBy = "System" };
                var tag2 = new SystemTag { ID = 12, TagName = "Adventure", CreatedBy = "System" };

                context.Games_Info.AddRange(game1, game2);
                context.System_Tags.AddRange(tag1, tag2);

                context.Games_Tags.AddRange(
                    new GamesTag { GameID = game1.Id, TagID = tag1.ID, CreatedBy = "System" },
                    new GamesTag { GameID = game2.Id, TagID = tag2.ID, CreatedBy = "System" }
                );

                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesTagRepository(context);

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
            int tagId;
            using (var context = new DBContext(options))
            {
                var tag = new GamesTag
                {
                    GameID = 5,
                    TagID = 55,
                    CreatedBy = "OldUser"
                };
                context.Games_Tags.Add(tag);
                await context.SaveChangesAsync();
                tagId = tag.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesTagRepository(context);
                var updatedEntity = new GamesTag
                {
                    ID = tagId,
                    GameID = 6,
                    TagID = 66,
                    CreatedBy = "NewUser"
                };

                // Act
                var result = await repo.UpdateAsync(tagId, updatedEntity);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(6, result.GameID);
                Assert.AreEqual(66, result.TagID);
                Assert.AreEqual("NewUser", result.CreatedBy);
            }
        }
    }
}
