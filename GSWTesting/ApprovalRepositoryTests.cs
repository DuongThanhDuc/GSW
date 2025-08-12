using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using System.Threading.Tasks;
using BusinessModel.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class ApprovalRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private ApprovalRepository _repo;
        private Mock<DbSet<GamesInfo>> _gamesInfoSetMock;
        private Mock<DbSet<StoreRefundRequest>> _refundSetMock;
        private List<GamesInfo> _gamesData;
        private List<StoreRefundRequest> _refundData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _gamesInfoSetMock = new Mock<DbSet<GamesInfo>>();
            _refundSetMock = new Mock<DbSet<StoreRefundRequest>>();
            _gamesData = new List<GamesInfo> { new GamesInfo { Id = 1, Title = "Game1" } };
            _refundData = new List<StoreRefundRequest> { new StoreRefundRequest { ID = 1, OrderID = 1 } };
            var gamesQueryable = _gamesData.AsQueryable();
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.Provider).Returns(gamesQueryable.Provider);
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.Expression).Returns(gamesQueryable.Expression);
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.ElementType).Returns(gamesQueryable.ElementType);
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.GetEnumerator()).Returns(() => gamesQueryable.GetEnumerator());
            var refundQueryable = _refundData.AsQueryable();
            _refundSetMock.As<IQueryable<StoreRefundRequest>>().Setup(m => m.Provider).Returns(refundQueryable.Provider);
            _refundSetMock.As<IQueryable<StoreRefundRequest>>().Setup(m => m.Expression).Returns(refundQueryable.Expression);
            _refundSetMock.As<IQueryable<StoreRefundRequest>>().Setup(m => m.ElementType).Returns(refundQueryable.ElementType);
            _refundSetMock.As<IQueryable<StoreRefundRequest>>().Setup(m => m.GetEnumerator()).Returns(() => refundQueryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Games_Info).Returns(_gamesInfoSetMock.Object);
            _dbContextMock.Setup(x => x.Store_RefundRequests).Returns(_refundSetMock.Object);
            _repo = new ApprovalRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task ApproveGameAsync_ReturnsFalse_WhenGameNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _gamesInfoSetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((GamesInfo)null);
            // Act
            var result = await _repo.ApproveGameAsync(notFoundId, "Approved", "user1", "note");
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ApproveGameAsync_ReturnsTrue_WhenGameFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _gamesData.First(g => g.Id == foundId);
            _gamesInfoSetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.ApproveGameAsync(foundId, "Approved", "user1", "note");
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ApproveRefundAsync_ReturnsFalse_WhenRefundNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _refundSetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((StoreRefundRequest)null);
            // Act
            var result = await _repo.ApproveRefundAsync(notFoundId, "Approved", "user1", "note");
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ApproveRefundAsync_ReturnsTrue_WhenRefundFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _refundData.First(r => r.ID == foundId);
            _refundSetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.ApproveRefundAsync(foundId, "Approved", "user1", "note");
            // Assert
            Assert.IsTrue(result);
        }
    }
}
