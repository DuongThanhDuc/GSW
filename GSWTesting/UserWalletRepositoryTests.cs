using BusinessModel.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class WalletRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseSqlServer("Server=localhost;Database=GSW;User Id=sa;Password=123;TrustServerCertificate=True;")
                .Options;
        }

        private DBContext CreateContext(DbContextOptions<DBContext> options, bool ensureCreated = false)
        {
            var context = new DBContext(options);
            if (ensureCreated)
                context.Database.EnsureCreated(); // only call this once
            return context;
        }


        [Test]
        public async Task DecreaseIfEnoughAsync_ShouldDecreaseBalance_WhenEnoughFunds()
        {
            var options = CreateNewContextOptions();

            // Create DB and seed user + wallet
            using (var context = new DBContext(options))
            {
                context.Database.EnsureDeleted(); // delete old DB once
                context.Database.EnsureCreated(); // create fresh DB

                var userId = "bcbccd35-9a88-42cb-82d7-0c9e67f9d9af";

                context.Users.Add(new IdentityUser
                {
                    Id = userId,
                    UserName = "testuser1",
                    NormalizedUserName = "TESTUSER1",
                    Email = "test1@test.com",
                    NormalizedEmail = "TEST1@TEST.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = "AQAAAAIAAYagAAAAE..."
                });

                context.User_Wallets.Add(new UserWallet
                {
                    UserId = userId,
                    Balance = 100m,
                    UpdatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }

            // Use a new context without deleting DB
            using (var testContext = new DBContext(options))
            {
                var repo = new WalletRepository(testContext);

                var result = await repo.DecreaseIfEnoughAsync(
                    "bcbccd35-9a88-42cb-82d7-0c9e67f9d9af", 50m, CancellationToken.None);

                Assert.IsTrue(result);

                var balance = await repo.GetBalanceAsync(
                    "bcbccd35-9a88-42cb-82d7-0c9e67f9d9af");

                Assert.AreEqual(50m, balance);
            }
        }



        [Test]
        public async Task DecreaseIfEnoughAsync_ShouldFail_WhenInsufficientFunds()
        {
            var options = CreateNewContextOptions();
            var userId = Guid.NewGuid().ToString(); // <-- unique ID for each test

            using (var context = CreateContext(options))
            {
                // Create user
                context.Users.Add(new IdentityUser
                {
                    Id = userId,
                    UserName = "testuser2",
                    NormalizedUserName = "TESTUSER2",
                    Email = "test2@test.com",
                    NormalizedEmail = "TEST2@TEST.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = "AQAAAAIAAYagAAAAE..."
                });

                // Create wallet
                context.User_Wallets.Add(new UserWallet
                {
                    UserId = userId,
                    Balance = 20m,
                    UpdatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }

            using (var context = CreateContext(options))
            {
                var repo = new WalletRepository(context);

                var result = await repo.DecreaseIfEnoughAsync(userId, 50m, CancellationToken.None);
                Assert.IsFalse(result);

                var balance = await repo.GetBalanceAsync(userId);
                Assert.AreEqual(20m, balance); // balance should remain unchanged
            }
        }





        [Test]
        public async Task IncreaseAsync_ShouldIncreaseBalance()
        {
            var options = CreateNewContextOptions();
            var userId = Guid.NewGuid().ToString(); // unique user for test

            // Setup: create user and wallet
            using (var context = CreateContext(options))
            {
                context.Users.Add(new IdentityUser
                {
                    Id = userId,
                    UserName = "testuser3",
                    NormalizedUserName = "TESTUSER3",
                    Email = "test3@test.com",
                    NormalizedEmail = "TEST3@TEST.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = "AQAAAAIAAYagAAAAE..."
                });

                context.User_Wallets.Add(new UserWallet
                {
                    UserId = userId,
                    Balance = 30m,
                    UpdatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }

            // Test: increase wallet balance
            using (var context = CreateContext(options))
            {
                var repo = new WalletRepository(context);

                await repo.IncreaseAsync(userId, 20m, CancellationToken.None);

                var balance = await repo.GetBalanceAsync(userId);
                Assert.AreEqual(50m, balance); // 30 + 20
            }
        }

        [Test]
        public async Task IncreaseAsync_ShouldCreateWallet_WhenNotExists()
        {
            var options = CreateNewContextOptions();
            var userId = Guid.NewGuid().ToString(); // unique test user

            using (var context = CreateContext(options))
            {
                // create the user first
                context.Users.Add(new IdentityUser
                {
                    Id = userId,
                    UserName = "testuser4",
                    NormalizedUserName = "TESTUSER4",
                    Email = "test4@test.com",
                    NormalizedEmail = "TEST4@TEST.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = "AQAAAAIAAYagAAAAE..."
                });

                await context.SaveChangesAsync();
            }

            using (var context = CreateContext(options))
            {
                var repo = new WalletRepository(context);

                // now IncreaseAsync can safely create the wallet
                await repo.IncreaseAsync(userId, 100m, CancellationToken.None);

                var balance = await repo.GetBalanceAsync(userId);
                Assert.AreEqual(100m, balance);
            }
        }

    }
}
