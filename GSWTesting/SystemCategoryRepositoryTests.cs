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
    public class SystemCategoryRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewCategory()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var category = new SystemCategory
                {
                    CategoryName = "Action",
                    CreatedBy = "UnitTestUser"
                };

                await repo.AddAsync(category);

                var saved = context.System_Categories.First();
                Assert.AreEqual(1, context.System_Categories.Count());
                Assert.AreEqual("Action", saved.CategoryName);
                Assert.AreEqual("UnitTestUser", saved.CreatedBy);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnCategory()
        {
            var options = CreateNewContextOptions();
            int categoryId;
            using (var context = new DBContext(options))
            {
                var category = new SystemCategory { CategoryName = "Adventure", CreatedBy = "TestUser" };
                context.System_Categories.Add(category);
                await context.SaveChangesAsync();
                categoryId = category.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var result = await repo.GetByIdAsync(categoryId);

                Assert.NotNull(result);
                Assert.AreEqual("Adventure", result.CategoryName);
                Assert.AreEqual("TestUser", result.CreatedBy);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var result = await repo.GetByIdAsync(999);

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task GetByNameAsync_WhenEntityExists_ShouldReturnCategory()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_Categories.Add(new SystemCategory { CategoryName = "RPG", CreatedBy = "NameUser" });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var result = await repo.GetByNameAsync("RPG");

                Assert.NotNull(result);
                Assert.AreEqual("RPG", result.CategoryName);
                Assert.AreEqual("NameUser", result.CreatedBy);
            }
        }

        [Test]
        public async Task GetByNameAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var result = await repo.GetByNameAsync("NONEXIST");

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingCategory()
        {
            var options = CreateNewContextOptions();
            int categoryId;
            using (var context = new DBContext(options))
            {
                var category = new SystemCategory { CategoryName = "OldName", CreatedBy = "OriginalUser" };
                context.System_Categories.Add(category);
                await context.SaveChangesAsync();
                categoryId = category.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var updated = new SystemCategory { ID = categoryId, CategoryName = "NewName", CreatedBy = "UpdatedUser" };

                await repo.UpdateAsync(updated);

                var result = await context.System_Categories.FindAsync(categoryId);
                Assert.AreEqual("NewName", result.CategoryName);
                Assert.AreEqual("UpdatedUser", result.CreatedBy);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveCategory()
        {
            var options = CreateNewContextOptions();
            int categoryId;
            using (var context = new DBContext(options))
            {
                var category = new SystemCategory { CategoryName = "ToDelete", CreatedBy = "DeleteUser" };
                context.System_Categories.Add(category);
                await context.SaveChangesAsync();
                categoryId = category.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                await repo.DeleteAsync(categoryId);

                Assert.AreEqual(0, context.System_Categories.Count());
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCategories()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.System_Categories.AddRange(
                    new SystemCategory { CategoryName = "Cat1", CreatedBy = "User1" },
                    new SystemCategory { CategoryName = "Cat2", CreatedBy = "User2" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new SystemCategoryRepository(context);
                var results = (await repo.GetAllAsync()).ToList();

                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Any(c => c.CategoryName == "Cat1" && c.CreatedBy == "User1"));
                Assert.IsTrue(results.Any(c => c.CategoryName == "Cat2" && c.CreatedBy == "User2"));
            }
        }
    }
}
