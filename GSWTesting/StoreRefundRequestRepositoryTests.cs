using BusinessModel.Model;
using DataAccess.Repository.Data.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestFixture]
    public class StoreRefundRequestRepositoryTests
    {
        private DbContextOptions<DBContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewRefundRequest()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder
                {
                    OrderCode = "string",
                    UserID = "user1",
                    OrderDate = DateTime.Now,
                    TotalAmount = 200,
                    Status = "Completed"
                };
                context.Store_Orders.Add(order);
                await context.SaveChangesAsync();

                var repo = new StoreRefundRequestRepository(context);
                var request = new StoreRefundRequest
                {
                    OrderID = order.ID,
                    UserID = order.UserID,
                    Reason = "Defective item",
                    RequestDate = DateTime.Now,
                    Status = "Pending"
                };

                await repo.AddAsync(request);

                Assert.AreEqual(1, await context.Store_RefundRequests.CountAsync());
                Assert.AreEqual("Defective item", (await context.Store_RefundRequests.FirstAsync()).Reason);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnRefundRequest()
        {
            var options = CreateNewContextOptions();
            int requestId;
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder { OrderCode = "string2", UserID = "user2", OrderDate = DateTime.Now, TotalAmount = 150, Status = "Completed" };
                context.Store_Orders.Add(order);

                var request = new StoreRefundRequest { Order = order, UserID = order.UserID, Reason = "Late delivery", RequestDate = DateTime.Now, Status = "Approved" };
                context.Store_RefundRequests.Add(request);
                await context.SaveChangesAsync();

                requestId = request.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);
                var result = await repo.GetByIdAsync(requestId);

                Assert.NotNull(result);
                Assert.AreEqual("Late delivery", result.Reason);
                Assert.AreEqual("Approved", result.Status);
                Assert.NotNull(result.Order);
            }
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenDoesNotExist()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);

                var result = await repo.GetByIdAsync(999);

                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllRefundRequests()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var order1 = new StoreOrder { OrderCode = "string", UserID = "u1", OrderDate = DateTime.Now, TotalAmount = 100, Status = "Completed" };
                var order2 = new StoreOrder { OrderCode = "string2", UserID = "u2", OrderDate = DateTime.Now, TotalAmount = 300, Status = "Completed" };
                context.Store_Orders.AddRange(order1, order2);

                context.Store_RefundRequests.AddRange(
                    new StoreRefundRequest { Order = order1, UserID = order1.UserID, Reason = "Reason1", RequestDate = DateTime.Now, Status = "Pending" },
                    new StoreRefundRequest { Order = order2, UserID = order2.UserID, Reason = "Reason2", RequestDate = DateTime.Now, Status = "Rejected" }
                );
                await context.SaveChangesAsync();
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);
                var result = await repo.GetAllAsync();

                Assert.AreEqual(2, result.Count());
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoRefundRequestsExist()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);
                var result = await repo.GetAllAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Count());
            }
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyExistingRefundRequest()
        {
            var options = CreateNewContextOptions();
            int requestId;
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder { OrderCode = "string", UserID = "user3", OrderDate = DateTime.Now, TotalAmount = 250, Status = "Completed" };
                context.Store_Orders.Add(order);

                var request = new StoreRefundRequest { Order = order, UserID = order.UserID, Reason = "Wrong item", RequestDate = DateTime.Now, Status = "Pending" };
                context.Store_RefundRequests.Add(request);
                await context.SaveChangesAsync();

                requestId = request.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);
                var entity = await context.Store_RefundRequests.FirstAsync();
                entity.Reason = "Updated Reason";
                entity.Status = "Approved";

                await repo.UpdateAsync(entity);

                var updated = await context.Store_RefundRequests.FindAsync(requestId);
                Assert.AreEqual("Updated Reason", updated.Reason);
                Assert.AreEqual("Approved", updated.Status);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveRefundRequest()
        {
            var options = CreateNewContextOptions();
            int requestId;
            using (var context = new DBContext(options))
            {
                var order = new StoreOrder { OrderCode = "string", UserID = "user4", OrderDate = DateTime.Now, TotalAmount = 400, Status = "Completed" };
                context.Store_Orders.Add(order);

                var request = new StoreRefundRequest { Order = order, UserID = order.UserID, Reason = "Duplicate order", RequestDate = DateTime.Now, Status = "Pending" };
                context.Store_RefundRequests.Add(request);
                await context.SaveChangesAsync();

                requestId = request.ID;
            }

            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);
                await repo.DeleteAsync(requestId);

                Assert.AreEqual(0, await context.Store_RefundRequests.CountAsync());
            }
        }

        [Test]
        public async Task DeleteAsync_Should_DoNothing_WhenEntityDoesNotExist()
        {
            var options = CreateNewContextOptions();
            using (var context = new DBContext(options))
            {
                var repo = new StoreRefundRequestRepository(context);
                await repo.DeleteAsync(999);

                Assert.AreEqual(0, await context.Store_RefundRequests.CountAsync());
            }
        }
    }
}
