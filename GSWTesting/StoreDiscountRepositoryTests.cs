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
    public class GamesDiscountRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public void Create_ShouldAddNewDiscount()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var discount = new GamesDiscount
                {
                    Code = "DISC10",
                    Description = "10% Off",
                    Value = 10,
                    IsPercent = true,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(10),
                    IsActive = true
                };

                var result = repo.Create(discount);

                Assert.NotNull(result);
                Assert.AreEqual(1, context.Games_Discount.Count());
                Assert.AreEqual("DISC10", result.Code);
            }
        }

        [Test]
        public void Get_WhenEntityExists_ShouldReturnDiscount()
        {
            var options = CreateNewContextOptions();
            int discountId;
            using (var context = new DBContext(options))
            {
                var discount = new GamesDiscount
                {
                    Code = "DISC20",
                    Description = "20% Off",
                    Value = 20,
                    IsPercent = true,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(5),
                    IsActive = true
                };
                context.Games_Discount.Add(discount);
                context.SaveChanges();
                discountId = discount.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var result = repo.Get(discountId);

                Assert.NotNull(result);
                Assert.AreEqual("DISC20", result.Code);
            }
        }

        [Test]
        public void Get_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var result = repo.Get(999);

                Assert.IsNull(result);
            }
        }

        [Test]
        public void Update_ShouldModifyExistingDiscount()
        {
            var options = CreateNewContextOptions();
            int discountId;
            using (var context = new DBContext(options))
            {
                var discount = new GamesDiscount
                {
                    Code = "DISC30",
                    Description = "30% Off",
                    Value = 30,
                    IsPercent = true,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(3),
                    IsActive = true
                };
                context.Games_Discount.Add(discount);
                context.SaveChanges();
                discountId = discount.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var updated = new GamesDiscount
                {
                    Code = "DISC30NEW",
                    Description = "Updated discount",
                    Value = 15,
                    IsPercent = false,
                    StartDate = DateTime.UtcNow.AddDays(-1),
                    EndDate = DateTime.UtcNow.AddDays(7),
                    IsActive = false
                };

                var result = repo.Update(discountId, updated);

                Assert.NotNull(result);
                Assert.AreEqual("DISC30NEW", result.Code);
                Assert.AreEqual(15, result.Value);
                Assert.IsFalse(result.IsActive);
            }
        }

        [Test]
        public void Update_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var updated = new GamesDiscount { Code = "DISCXX" };

                var result = repo.Update(999, updated);

                Assert.IsNull(result);
            }
        }

        [Test]
        public void Delete_ShouldRemoveDiscount()
        {
            var options = CreateNewContextOptions();
            int discountId;
            using (var context = new DBContext(options))
            {
                var discount = new GamesDiscount
                {
                    Code = "DISC40",
                    Description = "40% Off",
                    Value = 40,
                    IsPercent = true,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(2),
                    IsActive = true
                };
                context.Games_Discount.Add(discount);
                context.SaveChanges();
                discountId = discount.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                repo.Delete(discountId);

                Assert.AreEqual(0, context.Games_Discount.Count());
            }
        }

        [Test]
        public void IsCodeExist_WhenCodeExists_ShouldReturnTrue()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Discount.Add(new GamesDiscount { Code = "DISC50", Description = "TestDescription1", Value = 50, IsPercent = true, CreatedAt = DateTime.UtcNow });
                context.SaveChanges();

                var repo = new GamesDiscountRepository(context);
                var exists = repo.IsCodeExist("DISC50");

                Assert.IsTrue(exists);
            }
        }

        [Test]
        public void IsCodeExist_WhenCodeDoesNotExist_ShouldReturnFalse()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var exists = repo.IsCodeExist("NONEXIST");

                Assert.IsFalse(exists);
            }
        }

        [Test]
        public void GetAll_ShouldReturnAllDiscounts()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Discount.AddRange(
                    new GamesDiscount { Code = "DISC60", Description = "TestDescription1", Value = 60, CreatedAt = DateTime.UtcNow },
                    new GamesDiscount { Code = "DISC70", Description = "TestDescription2", Value = 70, CreatedAt = DateTime.UtcNow.AddMinutes(1) }
                );
                context.SaveChanges();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var results = repo.GetAll().ToList();

                Assert.AreEqual(2, results.Count);
                Assert.AreEqual("DISC70", results.First().Code); // ordered by CreatedAt desc
            }
        }

        [Test]
        public void GetActiveDiscountByGameId_ShouldReturnActiveDiscount()
        {
            var options = CreateNewContextOptions();
            int discountId;
            int gameId;
            using (var context = new DBContext(options))
            {
                var discount = new GamesDiscount
                {
                    Code = "DISC80",
                    Description = "TestDescription",
                    Value = 80,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };
                context.Games_Discount.Add(discount);
                context.SaveChanges();
                discountId = discount.Id;

                var game = new GamesInfo { Title = "Game1", Description = "desc", Price = 10, Genre = "Action", DeveloperId = "Dev1", InstallerFilePath = "setup.exe", CoverImagePath = "cover.jpg", CreatedBy = "Admin", IsActive = true };
                context.Games_Info.Add(game);
                context.SaveChanges();
                gameId = game.Id;

                context.Games_InfoDiscounts.Add(new GamesInfoDiscount { GamesInfoId = gameId, GamesDiscountId = discountId });
                context.SaveChanges();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesDiscountRepository(context);
                var result = repo.GetActiveDiscountByGameId(gameId);

                Assert.NotNull(result);
                Assert.AreEqual("DISC80", result.Code);
            }
        }
    }
}
