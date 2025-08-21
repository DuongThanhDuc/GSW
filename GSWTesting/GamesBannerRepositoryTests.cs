using DataAccess.Repository;
using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using BusinessModel.Model;

namespace UnitTests.Repository
{
    [TestFixture]
    public class GamesBannerRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: $"GamesBannerTestDb_{System.Guid.NewGuid()}")
                .Options;
        }

        [Test]
        public void CreateBanner_ShouldAddBannerToDatabase()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesBannerRepository(context);
                var dto = new GamesBannerDTO
                {
                    Title = "Test Banner",
                    ImageUrl = "http://test.com/image.jpg",
                    Link = "http://test.com",
                    IsActive = true
                };

                // Act
                repo.CreateBanner(dto);
            }

            // Assert
            using (var context = new DBContext(options))
            {
                Assert.AreEqual(1, context.Games_Banner.Count());
                var banner = context.Games_Banner.First();
                Assert.AreEqual("Test Banner", banner.Title);
            }
        }

        [Test]
        public void GetBannerById_WhenExists_ShouldReturnBanner()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Banner.Add(new BusinessModel.Model.GamesBanner
                {
                    Title = "Banner 1",
                    ImageUrl = "img1.jpg",
                    Link = "link1",
                    IsActive = true
                });
                context.SaveChanges();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesBannerRepository(context);

                // Act
                var result = repo.GetBannerById(1);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("Banner 1", result.Title);
            }
        }

        [Test]
        public void UpdateBanner_WhenExists_ShouldModifyBanner()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Banner.Add(new BusinessModel.Model.GamesBanner
                {
                    Title = "Old Title",
                    ImageUrl = "old.jpg",
                    Link = "old-link",
                    IsActive = false
                });
                context.SaveChanges();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesBannerRepository(context);
                var dto = new GamesBannerDTO
                {
                    Title = "New Title",
                    ImageUrl = "new.jpg",
                    Link = "new-link",
                    IsActive = true
                };

                // Act
                repo.UpdateBanner(1, dto);
            }

            using (var context = new DBContext(options))
            {
                var banner = context.Games_Banner.First();
                Assert.AreEqual("New Title", banner.Title);
                Assert.AreEqual("new.jpg", banner.ImageUrl);
                Assert.AreEqual("new-link", banner.Link);
                Assert.IsTrue(banner.IsActive);
            }
        }

        [Test]
        public void DeleteBanner_WhenExists_ShouldRemoveBanner()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Banner.Add(new BusinessModel.Model.GamesBanner
                {
                    Title = "ToDelete",
                    ImageUrl = "del.jpg",
                    Link = "del-link",
                    IsActive = false
                });
                context.SaveChanges();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesBannerRepository(context);

                // Act
                repo.DeleteBanner(1);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, context.Games_Banner.Count());
            }
        }

        [Test]
        public void GetAllBanners_WhenCalled_ShouldReturnAllBanners()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Banner.AddRange(
                    new BusinessModel.Model.GamesBanner
                    {
                        Title = "Banner 1",
                        ImageUrl = "img1.jpg",
                        Link = "link1",
                        IsActive = true
                    },
                    new BusinessModel.Model.GamesBanner
                    {
                        Title = "Banner 2",
                        ImageUrl = "img2.jpg",
                        Link = "link2",
                        IsActive = false
                    }
                );
                context.SaveChanges();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesBannerRepository(context);

                // Act
                var result = repo.GetAllBanners().ToList();

                // Assert
                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.Any(b => b.Title == "Banner 1"));
                Assert.IsTrue(result.Any(b => b.Title == "Banner 2"));
            }
        }
    }
}
