using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using BusinessModel.Model;
using DataAccess.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class StoreOrderRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private StoreOrderRepository _repo;
        private Mock<DbSet<StoreOrder>> _orderSetMock;
        private List<StoreOrder> _orderData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _orderSetMock = new Mock<DbSet<StoreOrder>>();
            _orderData = new List<StoreOrder>
            {
                new StoreOrder { ID = 1, UserID = "user1", TotalAmount = 100 },
                new StoreOrder { ID = 2, UserID = "user2", TotalAmount = 200 }
            };
            var queryable = _orderData.AsQueryable();
            _orderSetMock.As<IQueryable<StoreOrder>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _orderSetMock.As<IQueryable<StoreOrder>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _orderSetMock.As<IQueryable<StoreOrder>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _orderSetMock.As<IQueryable<StoreOrder>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Store_Orders).Returns(_orderSetMock.Object);
            _repo = new StoreOrderRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _orderSetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((StoreOrder)null);
            // Act
            var result = await _repo.GetByIdAsync(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsOrder_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _orderData.First(o => o.ID == foundId);
            _orderSetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.GetByIdAsync(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.UserID, result.UserID);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllOrders()
        {
            // Act
            var result = await _repo.GetAllAsync();
            // Assert
            Assert.AreEqual(_orderData.Count, result.Count());
        }
    }
}
