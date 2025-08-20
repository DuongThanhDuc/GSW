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
    public class GamesMediaRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddMediaToGame_ShouldAddNewMedia()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int gameId;
            using (var context = new DBContext(options))
            {
                var game = new GamesInfo
                {
                    Title = "Test Game",
                    Description = "Description",
                    Price = 9.99m,
                    Genre = "Action",
                    DeveloperId = "Dev1",
                    InstallerFilePath = "installer.exe",
                    CoverImagePath = "cover.png",
                    Status = "Draft",
                    IsActive = true,
                    CreatedBy = "Tester"
                };
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();
                gameId = game.Id;
            }

            var dto = new GamesMediaDTO
            {
                MediaURL = "media1.png",
                MediaType = "Image"
            };

            using (var context = new DBContext(options))
            {
                var repo = new GamesMediaRepository(context);

                // Act
                repo.AddMediaToGame(gameId, dto);
            }

            using (var context = new DBContext(options))
            {
                // Assert
                Assert.AreEqual(1, await context.Games_Media.CountAsync());
                var media = await context.Games_Media.FirstAsync();
                Assert.AreEqual("media1.png", media.MediaURL);
            }
        }

        [Test]
        public async Task GetGameInfoWithMedia_WhenGameExists_ShouldReturnGameInfo()
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

                context.Games_Media.Add(new GamesMedia
                {
                    GameID = gameId,
                    MediaURL = "video.mp4",
                    MediaType = "Video"
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesMediaRepository(context);

                // Act
                var result = repo.GetGameInfoWithMedia(gameId);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("Existing Game", result.Title);
                Assert.AreEqual("RPG", result.Genre);
            }
        }

        [Test]
        public async Task UpdateMediaInGame_ShouldModifyExistingMedia()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int gameId, mediaId;
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
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();
                gameId = game.Id;

                var media = new GamesMedia { GameID = gameId, MediaURL = "old.png", MediaType = "Image" };
                context.Games_Media.Add(media);
                await context.SaveChangesAsync();
                mediaId = media.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesMediaRepository(context);
                var dto = new GamesMediaDTO { Id = mediaId, MediaURL = "updated.png", MediaType = "Video" };

                // Act
                repo.UpdateMediaInGame(gameId, dto);
            }

            using (var context = new DBContext(options))
            {
                var updated = await context.Games_Media.FindAsync(mediaId);
                Assert.AreEqual("updated.png", updated.MediaURL);
                Assert.AreEqual("Video", updated.MediaType);
            }
        }

        [Test]
        public async Task DeleteMediaFromGame_ShouldRemoveMedia()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int gameId, mediaId;
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
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();
                gameId = game.Id;

                var media = new GamesMedia { GameID = gameId, MediaURL = "delete.png", MediaType = "Image" };
                context.Games_Media.Add(media);
                await context.SaveChangesAsync();
                mediaId = media.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesMediaRepository(context);

                // Act
                repo.DeleteMediaFromGame(gameId, mediaId);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Games_Media.CountAsync());
            }
        }

        [Test]
        public async Task GetMediaById_WhenExists_ShouldReturnMedia()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int mediaId;
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
                context.Games_Info.Add(game);
                await context.SaveChangesAsync();

                var media = new GamesMedia { GameID = game.Id, MediaURL = "find.png", MediaType = "Image" };
                context.Games_Media.Add(media);
                await context.SaveChangesAsync();
                mediaId = media.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesMediaRepository(context);

                // Act
                var result = repo.GetMediaById(mediaId);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("find.png", result.MediaURL);
            }
        }
    }
}
