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
    public class StoreLibraryRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewLibraryEntry()
        {
            var options = CreateNewContextOptions();
            var dto = new StoreLibraryDTO
            {
                UserID = "User1",
                GamesID = 100,
                CreatedAt = DateTime.UtcNow
            };

            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                await repo.AddAsync(dto);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(1, await context.Store_Library.CountAsync());
                var entry = await context.Store_Library.FirstAsync();
                Assert.AreEqual("User1", entry.UserID);
                Assert.AreEqual(100, entry.GamesID);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
        {
            var options = CreateNewContextOptions();
            int libId;
            using (var context = new DBContext(options))
            {
                var lib = new StoreLibrary { UserID = "UserX", GamesID = 200, CreatedAt = DateTime.UtcNow };
                context.Store_Library.Add(lib);
                await context.SaveChangesAsync();
                libId = lib.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var result = await repo.GetByIdAsync(libId);

                Assert.NotNull(result);
                Assert.AreEqual("UserX", result.UserID);
                Assert.AreEqual(200, result.GamesID);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var result = await repo.GetByIdAsync(999);

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllLibraries()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Store_Library.AddRange(
                    new StoreLibrary { UserID = "U1", GamesID = 10, CreatedAt = DateTime.UtcNow },
                    new StoreLibrary { UserID = "U2", GamesID = 20, CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var result = await repo.GetAllAsync();
                Assert.AreEqual(2, result.Count());
            }
        }

        [Test]
        public async Task GetAllAsync_WhenEmpty_ShouldReturnEmptyList()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var result = await repo.GetAllAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Count());
            }
        }

        [Test]
        public async Task GetByUserIdAsync_ShouldReturnLibrariesForUser()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Store_Library.AddRange(
                    new StoreLibrary { UserID = "SameUser", GamesID = 111, CreatedAt = DateTime.UtcNow },
                    new StoreLibrary { UserID = "SameUser", GamesID = 222, CreatedAt = DateTime.UtcNow },
                    new StoreLibrary { UserID = "OtherUser", GamesID = 333, CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var result = await repo.GetByUserIdAsync("SameUser");

                Assert.AreEqual(2, result.Count());
                Assert.True(result.All(x => x.UserID == "SameUser"));
            }
        }

        [Test]
        public async Task GetByUserIdAsync_WhenUserHasNoLibraries_ShouldReturnEmptyList()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var result = await repo.GetByUserIdAsync("nouser");

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Count());
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingEntity()
        {
            var options = CreateNewContextOptions();
            int libId;
            using (var context = new DBContext(options))
            {
                var lib = new StoreLibrary { UserID = "OldUser", GamesID = 999, CreatedAt = DateTime.UtcNow.AddDays(-1) };
                context.Store_Library.Add(lib);
                await context.SaveChangesAsync();
                libId = lib.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var updateDto = new StoreLibraryDTO { ID = libId, UserID = "UpdatedUser", GamesID = 123, CreatedAt = DateTime.UtcNow };
                await repo.UpdateAsync(updateDto);
            }

            using (var context = new DBContext(options))
            {
                var updated = await context.Store_Library.FindAsync(libId);
                Assert.AreEqual("UpdatedUser", updated.UserID);
                Assert.AreEqual(123, updated.GamesID);
            }
        }

        [Test]
        public async Task UpdateAsync_WhenEntityDoesNotExist_ShouldDoNothing()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                var dto = new StoreLibraryDTO { ID = 999, UserID = "User", GamesID = 1, CreatedAt = DateTime.UtcNow };
                await repo.UpdateAsync(dto);

                Assert.AreEqual(0, await context.Store_Library.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveEntity()
        {
            var options = CreateNewContextOptions();
            int libId;
            using (var context = new DBContext(options))
            {
                var lib = new StoreLibrary { UserID = "DelUser", GamesID = 555, CreatedAt = DateTime.UtcNow };
                context.Store_Library.Add(lib);
                await context.SaveChangesAsync();
                libId = lib.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                await repo.DeleteAsync(libId);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Store_Library.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_WhenEntityDoesNotExist_ShouldDoNothing()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreLibraryRepository(context);
                await repo.DeleteAsync(999);

                Assert.AreEqual(0, await context.Store_Library.CountAsync());
            }
        }
    }
}
