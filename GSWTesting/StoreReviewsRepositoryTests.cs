using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class GamesReviewRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewReview()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);

                var review = new GamesReview
                {
                    GameID = 1,
                    UserID = "User1",
                    Comment = "Great game!",
                    CreatedAt = DateTime.UtcNow,
                    IsUpvoted = true
                };

                await repo.AddAsync(review);

                Assert.AreEqual(1, await context.Games_Reviews.CountAsync());
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnReviewDTO()
        {
            var options = CreateNewContextOptions();
            int reviewId;
            using (var context = new DBContext(options))
            {
                var user = new IdentityUser { Id = "User1", UserName = "Tester" };
                context.Users.Add(user);

                var review = new GamesReview
                {
                    GameID = 1,
                    UserID = user.Id,
                    Comment = "Amazing!",
                    CreatedAt = DateTime.UtcNow,
                    IsUpvoted = true
                };
                context.Games_Reviews.Add(review);
                await context.SaveChangesAsync();
                reviewId = review.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);

                var result = await repo.GetByIdAsync(reviewId);

                Assert.NotNull(result);
                Assert.AreEqual("Tester", result.UserName);
                Assert.AreEqual("Amazing!", result.Comment);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllReviews()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Users.Add(new IdentityUser { Id = "User1", UserName = "Alice" });
                context.Users.Add(new IdentityUser { Id = "User2", UserName = "Bob" });

                context.Games_Reviews.AddRange(
                    new GamesReview { GameID = 1, UserID = "User1", Comment = "Nice", CreatedAt = DateTime.UtcNow },
                    new GamesReview { GameID = 2, UserID = "User2", Comment = "Meh", CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);

                var result = await repo.GetAllAsync();

                Assert.AreEqual(2, result.Count());
            }
        }

        [Test]
        public async Task GetByGameIdAsync_ShouldReturnReviewsForSpecificGame()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Users.Add(new IdentityUser { Id = "User1", UserName = "Alice" });

                context.Games_Reviews.AddRange(
                    new GamesReview { GameID = 10, UserID = "User1", Comment = "Fun", CreatedAt = DateTime.UtcNow },
                    new GamesReview { GameID = 20, UserID = "User1", Comment = "Bad", CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);

                var result = await repo.GetByGameIdAsync(10);

                Assert.AreEqual(1, result.Count());
                Assert.AreEqual("Fun", result.First().Comment);
            }
        }

        [Test]
        public async Task GetByUserIdAsync_ShouldReturnReviewsForSpecificUser()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Users.Add(new IdentityUser { Id = "UserX", UserName = "Charlie" });

                context.Games_Reviews.AddRange(
                    new GamesReview { GameID = 1, UserID = "UserX", Comment = "Cool", CreatedAt = DateTime.UtcNow },
                    new GamesReview { GameID = 2, UserID = "UserX", Comment = "Okay", CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);

                var result = await repo.GetByUserIdAsync("UserX");

                Assert.AreEqual(2, result.Count());
                Assert.IsTrue(result.Any(r => r.Comment == "Cool"));
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingReview()
        {
            var options = CreateNewContextOptions();
            int reviewId;
            using (var context = new DBContext(options))
            {
                var review = new GamesReview
                {
                    GameID = 1,
                    UserID = "User1",
                    Comment = "Old Comment",
                    CreatedAt = DateTime.UtcNow
                };
                context.Games_Reviews.Add(review);
                await context.SaveChangesAsync();
                reviewId = review.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);

                var updated = new GamesReview
                {
                    ID = reviewId,
                    GameID = 1,
                    UserID = "User1",
                    Comment = "Updated Comment",
                    CreatedAt = DateTime.UtcNow
                };

                await repo.UpdateAsync(updated);
            }

            using (var context = new DBContext(options))
            {
                var review = await context.Games_Reviews.FindAsync(reviewId);
                Assert.AreEqual("Updated Comment", review.Comment);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveReview()
        {
            var options = CreateNewContextOptions();
            int reviewId;
            using (var context = new DBContext(options))
            {
                var review = new GamesReview
                {
                    GameID = 1,
                    UserID = "User1",
                    Comment = "Delete Me",
                    CreatedAt = DateTime.UtcNow
                };
                context.Games_Reviews.Add(review);
                await context.SaveChangesAsync();
                reviewId = review.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);
                await repo.DeleteAsync(reviewId);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Games_Reviews.CountAsync());
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new GamesReviewRepository(context);
                var result = await repo.GetByIdAsync(999);
                Assert.IsNull(result);
            }
        }
    }
}
