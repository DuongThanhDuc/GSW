using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using BusinessModel.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class PaymentRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private PaymentRepository _repo;
        private Mock<DbSet<PaymentTransaction>> _txSetMock;
        private List<PaymentTransaction> _txData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _txSetMock = new Mock<DbSet<PaymentTransaction>>();
            _txData = new List<PaymentTransaction>
            {
                new PaymentTransaction { Id = 1, OrderId = "ORDER1" },
                new PaymentTransaction { Id = 2, OrderId = "ORDER2" }
            };
            var queryable = _txData.AsQueryable();
            _txSetMock.As<IQueryable<PaymentTransaction>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _txSetMock.As<IQueryable<PaymentTransaction>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _txSetMock.As<IQueryable<PaymentTransaction>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _txSetMock.As<IQueryable<PaymentTransaction>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.PaymentTransactions).Returns(_txSetMock.Object);
            _repo = new PaymentRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetByOrderIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            string notFoundOrderId = "NOTFOUND";
            _txSetMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<PaymentTransaction, bool>>>(), default)).ReturnsAsync((PaymentTransaction)null);
            // Act
            var result = await _repo.GetByOrderIdAsync(notFoundOrderId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByOrderIdAsync_ReturnsTransaction_WhenFound()
        {
            // Arrange
            string foundOrderId = "ORDER1";
            var expected = _txData.First(t => t.OrderId == foundOrderId);
            _txSetMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<PaymentTransaction, bool>>>(), default)).ReturnsAsync(expected);
            // Act
            var result = await _repo.GetByOrderIdAsync(foundOrderId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.OrderId, result.OrderId);
        }
    }
}
