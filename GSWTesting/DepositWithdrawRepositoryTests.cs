using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using System.Threading.Tasks;
using BusinessModel.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class DepositWithdrawRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private DepositWithdrawRepository _repo;
        private Mock<DbSet<DepositWithdrawTransaction>> _txSetMock;
        private List<DepositWithdrawTransaction> _txData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _txSetMock = new Mock<DbSet<DepositWithdrawTransaction>>();
            _txData = new List<DepositWithdrawTransaction>
            {
                new DepositWithdrawTransaction { Id = 1, Amount = 100 },
                new DepositWithdrawTransaction { Id = 2, Amount = 200 }
            };
            var queryable = _txData.AsQueryable();
            _txSetMock.As<IQueryable<DepositWithdrawTransaction>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _txSetMock.As<IQueryable<DepositWithdrawTransaction>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _txSetMock.As<IQueryable<DepositWithdrawTransaction>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _txSetMock.As<IQueryable<DepositWithdrawTransaction>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.DepositWithdrawTransactions).Returns(_txSetMock.Object);
            _repo = new DepositWithdrawRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _txSetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((DepositWithdrawTransaction)null);
            // Act
            var result = await _repo.GetByIdAsync(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsTransaction_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _txData.First(t => t.Id == foundId);
            _txSetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.GetByIdAsync(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Amount, result.Amount);
        }

        //[Test]
        //public async Task GetAllAsync_ReturnsAllTransactions()
        //{
        //    // Act
        //    var result = await _repo.GetAllAsync();
        //    // Assert
        //    Assert.AreEqual(_txData.Count, result.Count());
        //}
    }
}
