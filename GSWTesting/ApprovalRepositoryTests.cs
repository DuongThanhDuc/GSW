using BusinessModel.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class ApprovalRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // ensures isolation
                .ConfigureWarnings(x =>
                    x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning)) // ✅ ignore transaction warnings
                .Options;
        }


        [Test]
        public async Task ApproveGameAsync_GameExists_ShouldUpdateStatusAndAddHistory()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.Games_Info.Add(new GamesInfo
                {
                    Id = 1,
                    Status = "Pending",
                    Title = "Test Game",
                    Description = "Test Description",
                    Genre = "Action",
                    DeveloperId = "string",
                    CoverImagePath = "cover.png",
                    InstallerFilePath = "installer.exe",
                    CreatedBy = "TestUser"
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new ApprovalRepository(context);

                // Act
                var result = await repo.ApproveGameAsync(1, "Approved", "User123", "Looks good");

                // Assert
                Assert.IsTrue(result);

                var game = await context.Games_Info.FindAsync(1);
                Assert.AreEqual("Approved", game.Status);

                var history = await context.ApprovalHistories.FirstOrDefaultAsync();
                Assert.NotNull(history);
                Assert.AreEqual("Game", history.EntityType);
                Assert.AreEqual(1, history.EntityId);
                Assert.AreEqual("Approved", history.Status);
                Assert.AreEqual("User123", history.ChangedByUserId);
                Assert.AreEqual("Looks good", history.Note);
            }
        }

        [Test]
        public async Task ApproveGameAsync_GameDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new ApprovalRepository(context);

            // Act
            var result = await repo.ApproveGameAsync(99, "Approved", "User123", "Does not exist");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ApproveRefundAsync_RefundExists_ShouldUpdateStatusAndAddHistory()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int refundId;

            using (var context = new DBContext(options))
            {
                var order = new StoreOrder
                {
                    OrderCode = "Order001",
                    UserID = "TestUser",
                    TotalAmount = 100m
                };

                var refund = new StoreRefundRequest
                {
                    Status = "Pending",
                    UserID = "TestUser",
                    Reason = "Test reason",
                    RequestDate = DateTime.UtcNow,
                    Order = order
                };
                context.Store_RefundRequests.Add(refund);
                await context.SaveChangesAsync();

                refundId = refund.ID;   // ✅ Get the actual ID
            }

            using (var context = new DBContext(options))
            {
                var repo = new ApprovalRepository(context);

                // Act
                var result = await repo.ApproveRefundAsync(refundId, "Approved", "User123", "Refund approved");

                // Assert
                Assert.IsTrue(result);

                var refund = await context.Store_RefundRequests.FindAsync(refundId);
                Assert.AreEqual("Approved", refund.Status);

                var history = await context.ApprovalHistories.FirstOrDefaultAsync();
                Assert.NotNull(history);
                Assert.AreEqual("Refund", history.EntityType);
                Assert.AreEqual(refundId, history.EntityId);
                Assert.AreEqual("Approved", history.Status);
                Assert.AreEqual("User123", history.ChangedByUserId);
                Assert.AreEqual("Refund approved", history.Note);
            }
        }


        [Test]
        public async Task ApproveRefundAsync_RefundDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new ApprovalRepository(context);

            // Act
            var result = await repo.ApproveRefundAsync(99, "Approved", "User123", "Refund missing");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
