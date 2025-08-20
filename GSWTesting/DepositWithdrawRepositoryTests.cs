using BusinessModel.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class DepositWithdrawRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // isolation per test
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldInsertTransactionWithPendingStatus()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using var context = new DBContext(options);
            var repo = new DepositWithdrawRepository(context);

            var tx = new DepositWithdrawTransaction
            {
                Id = 1,
                UserId = "TestUser",
                Amount = 100,
                Type = "Deposit"
            };

            // Act
            var result = await repo.CreateAsync(tx);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("Pending", result.Status);

            var saved = await context.DepositWithdrawTransactions.FindAsync(1);
            Assert.NotNull(saved);
            Assert.AreEqual("TestUser", saved.UserId);
            Assert.AreEqual(100, saved.Amount);
            Assert.AreEqual("Deposit", saved.Type);
            Assert.AreEqual("Pending", saved.Status);
        }

        [Test]
        public async Task GetByIdAsync_WhenTransactionExists_ShouldReturnTransaction()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.DepositWithdrawTransactions.Add(new DepositWithdrawTransaction
                {
                    Id = 1,
                    UserId = "TestUser",
                    Amount = 200,
                    Type = "Withdraw",
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new DepositWithdrawRepository(context);

                // Act
                var result = await repo.GetByIdAsync(1);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(200, result.Amount);
                Assert.AreEqual("Withdraw", result.Type);
            }
        }

        [Test]
        public async Task GetByUserAsync_ShouldReturnUserTransactionsOrderedByDate()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.DepositWithdrawTransactions.AddRange(
                    new DepositWithdrawTransaction
                    {
                        Id = 1,
                        UserId = "User123",
                        Amount = 50,
                        Type = "Deposit",
                        Status = "Pending",
                        CreatedAt = DateTime.UtcNow.AddMinutes(-10)
                    },
                    new DepositWithdrawTransaction
                    {
                        Id = 2,
                        UserId = "User123",
                        Amount = 75,
                        Type = "Withdraw",
                        Status = "Pending",
                        CreatedAt = DateTime.UtcNow
                    }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new DepositWithdrawRepository(context);

                // Act
                var results = await repo.GetByUserAsync("User123");

                // Assert
                Assert.AreEqual(2, results.Count);
                Assert.AreEqual(75, results[0].Amount); // newest first
                Assert.AreEqual(50, results[1].Amount);
            }
        }

        [Test]
        public async Task CountPendingAsync_ShouldReturnCorrectCount()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.DepositWithdrawTransactions.AddRange(
                    new DepositWithdrawTransaction { Id = 1, UserId = "U1", Status = "Pending", Amount = 100, Type = "Deposit" },
                    new DepositWithdrawTransaction { Id = 2, UserId = "U2", Status = "Approved", Amount = 200, Type = "Withdraw" },
                    new DepositWithdrawTransaction { Id = 3, UserId = "U3", Status = "Pending", Amount = 300, Type = "Deposit" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new DepositWithdrawRepository(context);

                // Act
                var count = await repo.CountPendingAsync();

                // Assert
                Assert.AreEqual(2, count);
            }
        }

        [Test]
        public async Task GetPendingAsync_ShouldReturnPendingTransactionsInOrder()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.DepositWithdrawTransactions.AddRange(
                    new DepositWithdrawTransaction { Id = 1, UserId = "U1", Status = "Pending", Amount = 100, Type = "Deposit", CreatedAt = DateTime.UtcNow.AddMinutes(-5) },
                    new DepositWithdrawTransaction { Id = 2, UserId = "U2", Status = "Pending", Amount = 200, Type = "Withdraw", CreatedAt = DateTime.UtcNow.AddMinutes(-10) }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new DepositWithdrawRepository(context);

                // Act
                var results = await repo.GetPendingAsync(0, 10);

                // Assert
                Assert.AreEqual(2, results.Count);
                Assert.AreEqual(2, results[0].Id); // oldest first
                Assert.AreEqual(1, results[1].Id);
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyTransaction()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                context.DepositWithdrawTransactions.Add(new DepositWithdrawTransaction
                {
                    Id = 1,
                    UserId = "UserX",
                    Amount = 150,
                    Type = "Deposit",
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new DepositWithdrawRepository(context);
                var tx = await repo.GetByIdAsync(1);

                // Act
                tx.Status = "Approved";
                await repo.UpdateAsync(tx);
            }

            using (var context = new DBContext(options))
            {
                var updated = await context.DepositWithdrawTransactions.FindAsync(1);

                // Assert
                Assert.NotNull(updated);
                Assert.AreEqual("Approved", updated.Status);
            }
        }
    }
}
