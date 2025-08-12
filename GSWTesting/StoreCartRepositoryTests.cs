using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using BusinessModel.Model;
using DataAccess.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccess.Repository.IRepository;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class StoreCartRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private Mock<IGamesInfoRepository> _gamesRepoMock;
        private StoreCartRepository _repo;
        private Mock<DbSet<StoreCart>> _cartSetMock;
        private List<StoreCart> _cartData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _gamesRepoMock = new Mock<IGamesInfoRepository>();
            _cartSetMock = new Mock<DbSet<StoreCart>>();
            _cartData = new List<StoreCart>
            {
                new StoreCart { ID = 1, UserID = "user1", GameID = 1 },
                new StoreCart { ID = 2, UserID = "user2", GameID = 2 }
            };
            var queryable = _cartData.AsQueryable();
            _cartSetMock.As<IQueryable<StoreCart>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _cartSetMock.As<IQueryable<StoreCart>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _cartSetMock.As<IQueryable<StoreCart>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _cartSetMock.As<IQueryable<StoreCart>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Store_Cart).Returns(_cartSetMock.Object);
            _repo = new StoreCartRepository(_dbContextMock.Object, _gamesRepoMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _cartSetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((StoreCart)null);
            // Act
            var result = await _repo.GetByIdAsync(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCart_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _cartData.First(c => c.ID == foundId);
            _cartSetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.GetByIdAsync(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.UserID, result.UserID);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllCarts()
        {
            // Act
            var result = await _repo.GetAllAsync();
            // Assert
            Assert.AreEqual(_cartData.Count, result.Count());
        }
    }
}
