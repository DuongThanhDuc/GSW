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
    public class SystemTagRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewTag()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemTagRepository(context);
                var tag = new SystemTag
                {
                    TagName = "TestTag",
                    CreatedBy = "TestUser"
                };

                await repo.AddAsync(tag);

                var saved = context.System_Tags.First();
                Assert.AreEqual(1, context.System_Tags.Count());
                Assert.AreEqual("TestTag", saved.TagName);
                Assert.AreEqual("TestUser", saved.CreatedBy);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenExists_ShouldReturnTag()
        {
            var options = CreateNewContextOptions();
            int id;
            using (var context = new DBContext(options))
            {
                var tag = new SystemTag { TagName = "Tag1", CreatedBy = "User1" };
                context.System_Tags.Add(tag);
                await context.SaveChangesAsync();
                id = tag.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemTagRepository(context);
                var result = await repo.GetByIdAsync(id);

                Assert.NotNull(result);
                Assert.AreEqual("Tag1", result.TagName);
                Assert.AreEqual("User1", result.CreatedBy);
            }
        }

        [Test]
        public async Task GetByNameAsync_WhenExists_ShouldReturnTag()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_Tags.Add(new SystemTag { TagName = "TagX", CreatedBy = "User2" });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemTagRepository(context);
                var result = await repo.GetByNameAsync("TagX");

                Assert.NotNull(result);
                Assert.AreEqual("TagX", result.TagName);
                Assert.AreEqual("User2", result.CreatedBy);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllTags()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_Tags.AddRange(
                    new SystemTag { TagName = "T1", CreatedBy = "U1" },
                    new SystemTag { TagName = "T2", CreatedBy = "U2" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemTagRepository(context);
                var results = (await repo.GetAllAsync()).ToList();

                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Any(r => r.TagName == "T1" && r.CreatedBy == "U1"));
                Assert.IsTrue(results.Any(r => r.TagName == "T2" && r.CreatedBy == "U2"));
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingTag()
        {
            var options = CreateNewContextOptions();
            int id;
            using (var context = new DBContext(options))
            {
                var tag = new SystemTag { TagName = "OldTag", CreatedBy = "User3" };
                context.System_Tags.Add(tag);
                await context.SaveChangesAsync();
                id = tag.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemTagRepository(context);
                var updated = new SystemTag { ID = id, TagName = "UpdatedTag", CreatedBy = "User3" };

                await repo.UpdateAsync(updated);

                var result = await context.System_Tags.FindAsync(id);
                Assert.AreEqual("UpdatedTag", result.TagName);
                Assert.AreEqual("User3", result.CreatedBy);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveTag()
        {
            var options = CreateNewContextOptions();
            int id;
            using (var context = new DBContext(options))
            {
                var tag = new SystemTag { TagName = "DeleteTag", CreatedBy = "User4" };
                context.System_Tags.Add(tag);
                await context.SaveChangesAsync();
                id = tag.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemTagRepository(context);
                await repo.DeleteAsync(id);

                Assert.AreEqual(0, context.System_Tags.Count());
            }
        }
    }
}
