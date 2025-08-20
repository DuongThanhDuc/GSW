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
    public class StoreOrderRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewOrder()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var dto = new StoreOrderDTO
            {
                UserID = "user1",
                TotalAmount = 100,
                Status = "PENDING",
                OrderDate = DateTime.UtcNow
            };

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.CreateAsync(dto);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("user1", result.UserID);
                Assert.AreEqual(1, await context.Store_Orders.CountAsync());
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnOrder()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int orderId;

            using (var context = new DBContext(options))
            {
                var user = new IdentityUser
                {
                    Id = "user1",
                    UserName = "testuser",
                    Email = "test@example.com",
                    PhoneNumber = "123456789"
                };
                context.Users.Add(user);

                var order = new StoreOrder
                {
                    OrderCode = "String",
                    UserID = user.Id,
                    OrderDate = DateTime.Now,
                    TotalAmount = 100,
                    Status = "Pending"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();
                orderId = order.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.GetByIdAsync(orderId);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("testuser", result.UserName);
                Assert.AreEqual(100, result.TotalAmount);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var options = CreateNewContextOptions();

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.GetByIdAsync(999);

                // Assert
                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveOrder()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int orderId;
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder
                {
                    UserID = "user3",
                    TotalAmount = 50,
                    Status = "DRAFT",
                    OrderDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    OrderCode = "DEL123"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();
                orderId = order.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.DeleteAsync(orderId);

                // Assert
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                Assert.AreEqual(0, await context.Store_Orders.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_WhenEntityDoesNotExist_ShouldReturnFalse()
        {
            var options = CreateNewContextOptions();

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.DeleteAsync(999);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllOrders()
        {
            var options = CreateNewContextOptions();

            using (var context = new DBContext(options))
            {
                var user1 = new IdentityUser { Id = "user1", UserName = "u1", Email = "u1@test.com" };
                var user2 = new IdentityUser { Id = "user2", UserName = "u2", Email = "u2@test.com" };
                context.Users.AddRange(user1, user2);

                context.Store_Orders.AddRange(
                    new StoreOrder { OrderCode = "String", UserID = user1.Id, TotalAmount = 50, Status = "Pending", OrderDate = DateTime.Now },
                    new StoreOrder { OrderCode = "String2", UserID = user2.Id, TotalAmount = 150, Status = "Completed", OrderDate = DateTime.Now }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.GetAllAsync();

                // Assert
                Assert.AreEqual(2, result.Count());
            }
        }

        [Test]
        public async Task GetAllAsync_WhenNoOrdersExist_ShouldReturnEmptyList()
        {
            var options = CreateNewContextOptions();

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);

                // Act
                var result = await repo.GetAllAsync();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(0, result.Count());
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingOrder()
        {
            // Arrange
            var options = CreateNewContextOptions();
            int orderId;
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder
                {
                    UserID = "userX",
                    TotalAmount = 300,
                    Status = "PENDING",
                    OrderDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    OrderCode = "UPD123"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();
                orderId = order.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);
                var updateDto = new StoreOrderDTO
                {
                    UserID = "userX",
                    TotalAmount = 500,
                    Status = "COMPLETED",
                    OrderDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };

                // Act
                var result = await repo.UpdateAsync(orderId, updateDto);

                // Assert
                Assert.IsTrue(result);
            }

            using (var context = new DBContext(options))
            {
                var updated = await context.Store_Orders.FindAsync(orderId);
                Assert.AreEqual(500, updated.TotalAmount);
                Assert.AreEqual("COMPLETED", updated.Status);
            }
        }

        [Test]
        public async Task UpdateAsync_WhenEntityDoesNotExist_ShouldReturnFalse()
        {
            var options = CreateNewContextOptions();

            using (var context = new DBContext(options))
            {
                var repo = new StoreOrderRepository(context);
                var updateDto = new StoreOrderDTO
                {
                    UserID = "userX",
                    TotalAmount = 500,
                    Status = "COMPLETED",
                    OrderDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };

                // Act
                var result = await repo.UpdateAsync(999, updateDto);

                // Assert
                Assert.IsFalse(result);
            }
        }
    }
}
