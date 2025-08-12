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
    public class GamesInfoRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private GamesInfoRepository _repo;
        private Mock<DbSet<GamesInfo>> _gamesInfoSetMock;
        private List<GamesInfo> _gamesData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _gamesInfoSetMock = new Mock<DbSet<GamesInfo>>();
            _gamesData = new List<GamesInfo>
            {
                new GamesInfo { Id = 1, Title = "Game1" },
                new GamesInfo { Id = 2, Title = "Game2" }
            };
            var queryable = _gamesData.AsQueryable();
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _gamesInfoSetMock.As<IQueryable<GamesInfo>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Games_Info).Returns(_gamesInfoSetMock.Object);
            _repo = new GamesInfoRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetByIdAsyncOriginal_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _gamesInfoSetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((GamesInfo)null);
            // Act
            var result = await _repo.GetByIdAsyncOriginal(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByIdAsyncOriginal_ReturnsGame_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _gamesData.First(g => g.Id == foundId);
            _gamesInfoSetMock.Setup(x => x.FindAsync(foundId)).ReturnsAsync(expected);
            // Act
            var result = await _repo.GetByIdAsyncOriginal(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Title, result.Title);
        }

        [Test]
        public async Task GetAllAsyncOriginal_ReturnsAllGames()
        {
            // Act
            var result = await _repo.GetAllAsyncOriginal();
            // Assert
            Assert.AreEqual(_gamesData.Count, result.Count());
        }
    }
}
