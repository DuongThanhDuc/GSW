using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using BusinessModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Repository.Repository;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class GamesCategoryRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private GamesCategoryRepository _repo;
        private Mock<DbSet<GamesCategory>> _categorySetMock;
        private List<GamesCategory> _categoryData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _categorySetMock = new Mock<DbSet<GamesCategory>>();
            _categoryData = new List<GamesCategory>
            {
                new GamesCategory { ID = 1, GameID = 1, CategoryID = 1 },
                new GamesCategory { ID = 2, GameID = 2, CategoryID = 2 }
            };
            var queryable = _categoryData.AsQueryable();
            _categorySetMock.As<IQueryable<GamesCategory>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _categorySetMock.As<IQueryable<GamesCategory>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _categorySetMock.As<IQueryable<GamesCategory>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _categorySetMock.As<IQueryable<GamesCategory>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Games_Categories).Returns(_categorySetMock.Object);
            _repo = new GamesCategoryRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _categorySetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((GamesCategory)null);
            // Act
            var result = await _repo.GetByIdAsync(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCategory_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _categoryData.First(c => c.ID == foundId);
            _categorySetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.GetByIdAsync(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.GameID, result.GameID);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllCategories()
        {
            // Act
            var result = await _repo.GetAllAsync();
            // Assert
            Assert.AreEqual(_categoryData.Count, result.Count());
        }
    }
}
