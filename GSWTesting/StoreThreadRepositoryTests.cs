using DataAccess.Repository;
using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using BusinessModel.Model;
using System;
using Microsoft.AspNetCore.Identity;

namespace UnitTests.Repository
{
    [TestFixture]
    public class StoreThreadRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions(string dbName)
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldAddThreadToDatabase()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = CreateNewContextOptions(dbName);

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadRepository(context);
                var dto = new StoreThreadDTO
                {
                    ThreadTitle = "Test Thread",
                    ThreadDescription = "Description",
                    ThreadImageUrl = "http://img.com/thread.jpg",
                    CreatedBy = "user1"
                };

                var result = await repo.CreateAsync(dto);

                Assert.NotNull(result);
                Assert.Greater(result.Id, 0);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(1, context.Store_Threads.Count());
                var thread = context.Store_Threads.First();
                Assert.AreEqual("Test Thread", thread.ThreadTitle);
            }
        }
        [Test]
        public async Task GetByIdAsync_WhenExists_ShouldReturnThread()
        {
            var options = CreateNewContextOptions(Guid.NewGuid().ToString());

            int threadId;
            using (var context = new DBContext(options))
            {
                // 🔥 Seed user because repo joins StoreThread -> User
                var user = new IdentityUser
                {
                    Id = "User1",
                    UserName = "testuser",
                    Email = "test@example.com"
                };
                context.Users.Add(user);

                var thread = new StoreThread
                {
                    ThreadTitle = "Test Thread",
                    ThreadDescription = "Test Description",
                    ThreadImageUrl = "http://img.com/test.jpg",
                    CreatedBy = user.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpvoteCount = 3
                };
                context.Store_Threads.Add(thread);
                await context.SaveChangesAsync();
                threadId = thread.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadRepository(context);

                var result = await repo.GetByIdAsync(threadId);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.ThreadTitle, Is.EqualTo("Test Thread"));
                Assert.That(result.ThreadDescription, Is.EqualTo("Test Description"));
                Assert.That(result.UpvoteCount, Is.EqualTo(3));
            }
        }




        [Test]
        public async Task UpdateAsync_WhenExists_ShouldModifyThread()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = CreateNewContextOptions(dbName);
            int threadId;

            using (var context = new DBContext(options))
            {
                var thread = new StoreThread
                {
                    ThreadTitle = "Old Title",
                    ThreadDescription = "Old Desc",
                    ThreadImageUrl = "old.jpg",
                    CreatedBy = "user1",
                    UpvoteCount = 0
                };
                context.Store_Threads.Add(thread);
                await context.SaveChangesAsync();
                threadId = thread.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadRepository(context);
                var dto = new StoreThreadDTO
                {
                    Id = threadId,
                    ThreadTitle = "New Title",
                    ThreadDescription = "New Desc",
                    ThreadImageUrl = "new.jpg",
                    CreatedBy = "user2",
                    UpvoteCount = 5
                };

                var result = await repo.UpdateAsync(dto);
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                var updated = context.Store_Threads.First();
                Assert.AreEqual("New Title", updated.ThreadTitle);
                Assert.AreEqual("New Desc", updated.ThreadDescription);
                Assert.AreEqual(5, updated.UpvoteCount);
                Assert.AreEqual("user2", updated.CreatedBy);
            }
        }

        [Test]
        public async Task DeleteAsync_WhenExists_ShouldRemoveThread()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = CreateNewContextOptions(dbName);
            int threadId;

            using (var context = new DBContext(options))
            {
                var thread = new StoreThread
                {
                    ThreadTitle = "ToDelete",
                    ThreadDescription = "Desc",
                    ThreadImageUrl = "del.jpg",
                    CreatedBy = "user1",
                    UpvoteCount = 0
                };
                context.Store_Threads.Add(thread);
                await context.SaveChangesAsync();
                threadId = thread.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadRepository(context);
                var result = await repo.DeleteAsync(threadId);
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, context.Store_Threads.Count());
            }
        }

        [Test]
        public async Task GetAllAsync_WhenCalled_ShouldReturnAllThreads()
        {
            var options = CreateNewContextOptions(Guid.NewGuid().ToString());

            using (var context = new DBContext(options))
            {
                var user1 = new IdentityUser { Id = "User1", UserName = "User One", Email = "u1@test.com" };
                var user2 = new IdentityUser { Id = "User2", UserName = "User Two", Email = "u2@test.com" };
                context.Users.AddRange(user1, user2);

                context.Store_Threads.AddRange(
                    new StoreThread
                    {
                        ThreadTitle = "Thread 1",
                        ThreadDescription = "Desc 1",
                        ThreadImageUrl = "1.jpg",
                        CreatedBy = user1.Id,
                        CreatedAt = DateTime.UtcNow,
                        UpvoteCount = 1
                    },
                    new StoreThread
                    {
                        ThreadTitle = "Thread 2",
                        ThreadDescription = "Desc 2",
                        ThreadImageUrl = "2.jpg",
                        CreatedBy = user2.Id,
                        CreatedAt = DateTime.UtcNow,
                        UpvoteCount = 2
                    }
                );

                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadRepository(context);

                var results = await repo.GetAllAsync();

                Assert.That(results.Count(), Is.EqualTo(2));
                Assert.That(results.Any(r => r.ThreadTitle == "Thread 1"));
                Assert.That(results.Any(r => r.ThreadTitle == "Thread 2"));
            }
        }

    }
}
