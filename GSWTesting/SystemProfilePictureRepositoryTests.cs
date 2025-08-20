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
    public class SystemProfilePictureRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewProfilePicture()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var dto = new SystemProfilePictureDTO
                {
                    UserId = "User1",
                    ImageUrl = "http://image1.png"
                };

                await repo.AddAsync(dto);

                var saved = context.System_ProfilePictures.First();
                Assert.AreEqual(1, context.System_ProfilePictures.Count());
                Assert.AreEqual("User1", saved.UserId);
                Assert.AreEqual("http://image1.png", saved.ImageUrl);
            }
        }

        [Test]
        public async Task GetByUserIdAsync_WhenExists_ShouldReturnProfilePicture()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_ProfilePictures.Add(new SystemProfilePicture
                {
                    UserId = "User2",
                    ImageUrl = "http://image2.png"
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var result = await repo.GetByUserIdAsync("User2");

                Assert.NotNull(result);
                Assert.AreEqual("User2", result.UserId);
                Assert.AreEqual("http://image2.png", result.ImageUrl);
            }
        }

        [Test]
        public async Task GetByUserIdAsync_WhenNotExists_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var result = await repo.GetByUserIdAsync("NonExistingUser");

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllProfilePictures()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_ProfilePictures.AddRange(
                    new SystemProfilePicture { UserId = "U1", ImageUrl = "http://u1.png" },
                    new SystemProfilePicture { UserId = "U2", ImageUrl = "http://u2.png" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var results = (await repo.GetAllAsync()).ToList();

                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Any(r => r.UserId == "U1" && r.ImageUrl == "http://u1.png"));
                Assert.IsTrue(results.Any(r => r.UserId == "U2" && r.ImageUrl == "http://u2.png"));
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingProfilePicture()
        {
            var options = CreateNewContextOptions();
            int id;
            using (var context = new DBContext(options))
            {
                var entity = new SystemProfilePicture { UserId = "User3", ImageUrl = "http://old.png" };
                context.System_ProfilePictures.Add(entity);
                await context.SaveChangesAsync();
                id = entity.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var dto = new SystemProfilePictureDTO { Id = id, UserId = "User3", ImageUrl = "http://updated.png" };

                await repo.UpdateAsync(dto);

                var result = await context.System_ProfilePictures.FindAsync(id);
                Assert.AreEqual("User3", result.UserId);
                Assert.AreEqual("http://updated.png", result.ImageUrl);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveProfilePicture()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_ProfilePictures.Add(new SystemProfilePicture { UserId = "User4", ImageUrl = "http://delete.png" });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                await repo.DeleteAsync("User4");

                Assert.AreEqual(0, context.System_ProfilePictures.Count());
            }
        }

        [Test]
        public async Task CreateOrUpdateAsync_WhenNotExists_ShouldCreateNew()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var dto = new SystemProfilePictureDTO { UserId = "User5", ImageUrl = "http://new.png" };

                await repo.CreateOrUpdateAsync(dto);

                Assert.AreEqual(1, context.System_ProfilePictures.Count());
                var saved = context.System_ProfilePictures.First();
                Assert.AreEqual("User5", saved.UserId);
                Assert.AreEqual("http://new.png", saved.ImageUrl);
            }
        }

        [Test]
        public async Task CreateOrUpdateAsync_WhenExists_ShouldUpdateExisting()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_ProfilePictures.Add(new SystemProfilePicture { UserId = "User6", ImageUrl = "http://old.png" });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemProfilePictureRepository(context);
                var dto = new SystemProfilePictureDTO { UserId = "User6", ImageUrl = "http://updated.png" };

                await repo.CreateOrUpdateAsync(dto);

                Assert.AreEqual(1, context.System_ProfilePictures.Count());
                var updated = context.System_ProfilePictures.First();
                Assert.AreEqual("User6", updated.UserId);
                Assert.AreEqual("http://updated.png", updated.ImageUrl);
            }
        }
    }
}
