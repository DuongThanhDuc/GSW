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
    public class StatisticRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private StatisticRepository _repo;
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
            _repo = new StatisticRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetRevenueStatisticAsync_ReturnsStatistic()
        {
            // Arrange
            var req = new RevenueStatisticRequestDTO { From = System.DateTime.Now.AddDays(-1), To = System.DateTime.Now };
            // Act
            var result = await _repo.GetRevenueStatisticAsync(req);
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
