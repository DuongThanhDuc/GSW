using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class StoreThreadReplyRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldAddReply()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);
                var dto = new StoreThreadReplyDTO
                {
                    ThreadID = 1,
                    ThreadComment = "This is a reply",
                    CommentImageUrl = "image.png",
                    CreatedBy = "User1"
                };

                // Act
                var result = await repo.CreateAsync(dto);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("This is a reply", result.ThreadComment);
                Assert.AreEqual(1, await context.Store_ThreadReplies.CountAsync());
            }
        }

        [Test]
        public void CreateAsync_ShouldThrow_WhenDtoIsNull()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                // Catch any exception
                var ex = Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await repo.CreateAsync(null));

                // Verify it’s the type we expect
                Assert.That(ex, Is.InstanceOf<ArgumentNullException>().Or.InstanceOf<NullReferenceException>(),
                    "Expected either ArgumentNullException or NullReferenceException");

                // (Optional) Log for clarity
                TestContext.WriteLine($"Caught exception: {ex.GetType().Name} - {ex.Message}");
            }
        }



        [Test]
        public async Task GetByIdAsync_ShouldReturnReply_WhenExists()
        {
            var options = CreateNewContextOptions();
            int replyId;

            using (var context = new DBContext(options))
            {
                // Seed a user
                context.Users.Add(new IdentityUser
                {
                    Id = "UserX",
                    UserName = "User X",
                    Email = "userx@email.com",
                });

                // Seed reply
                var reply = new StoreThreadReply
                {
                    ThreadID = 10,
                    ThreadComment = "Existing reply",
                    CreatedBy = "UserX"
                };
                context.Store_ThreadReplies.Add(reply);
                await context.SaveChangesAsync();

                replyId = reply.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                // Act
                var result = await repo.GetByIdAsync(replyId);

                // Assert
                Assert.NotNull(result);
                Assert.That(result, Is.TypeOf<StoreThreadReplyDTOReadOnly>());
                Assert.AreEqual("Existing reply", result.ThreadComment);
                Assert.AreEqual("User X", result.CreatedByUserName);
                Assert.AreEqual("userx@email.com", result.CreatedByEmail);
            }
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotExists()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                var result = await repo.GetByIdAsync(999);
                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveReply_WhenExists()
        {
            var options = CreateNewContextOptions();
            int replyId;
            using (var context = new DBContext(options))
            {
                var reply = new StoreThreadReply { ThreadID = 5, ThreadComment = "To delete", CreatedBy = "UserY" };
                context.Store_ThreadReplies.Add(reply);
                await context.SaveChangesAsync();
                replyId = reply.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                var result = await repo.DeleteAsync(replyId);

                Assert.True(result);
                Assert.AreEqual(0, await context.Store_ThreadReplies.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldReturnFalse_WhenNotExists()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);
                var result = await repo.DeleteAsync(12345);
                Assert.False(result);
            }
        }

        [Test]
        public async Task ToggleReplyUpvoteAsync_ShouldAddUpvote_WhenNoneExists()
        {
            var options = CreateNewContextOptions();
            int replyId;
            using (var context = new DBContext(options))
            {
                var reply = new StoreThreadReply
                {
                    ThreadID = 99,
                    ThreadComment = "Upvote test",
                    CreatedBy = "UserA",
                    UpvoteCount = 0
                };
                context.Store_ThreadReplies.Add(reply);
                await context.SaveChangesAsync();
                replyId = reply.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                var result = await repo.ToggleReplyUpvoteAsync("User1", replyId);

                Assert.True(result);
                var updatedReply = await context.Store_ThreadReplies.FindAsync(replyId);
                Assert.AreEqual(1, updatedReply.UpvoteCount);
            }
        }

        [Test]
        public async Task ToggleReplyUpvoteAsync_ShouldRemoveUpvote_WhenAlreadyExists()
        {
            var options = CreateNewContextOptions();
            int replyId;
            using (var context = new DBContext(options))
            {
                var reply = new StoreThreadReply { ThreadID = 100, ThreadComment = "Double toggle", CreatedBy = "UserB", UpvoteCount = 1 };
                context.Store_ThreadReplies.Add(reply);
                context.Store_ThreadReplyUpvoteHistories.Add(new StoreThreadReplyUpvoteHistory
                {
                    UserId = "User1",
                    ThreadCommentId = reply.Id,
                    CreatedAt = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
                replyId = reply.Id;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                var result = await repo.ToggleReplyUpvoteAsync("User1", replyId);

                Assert.False(result);
                var updatedReply = await context.Store_ThreadReplies.FindAsync(replyId);
                Assert.AreEqual(0, updatedReply.UpvoteCount);
            }
        }

        [Test]
        public async Task ToggleReplyUpvoteAsync_ShouldDoNothing_WhenReplyNotFound()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreThreadReplyRepository(context);

                var result = await repo.ToggleReplyUpvoteAsync("User1", 999);
                Assert.False(result);
            }
        }
    }
}
