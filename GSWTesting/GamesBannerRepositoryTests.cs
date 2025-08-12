using NUnit.Framework;
using DataAccess.Repository;
using Moq;
using BusinessModel.Model;
using DataAccess.DTOs;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Tests.Repository
{
    [TestFixture]
    public class GamesBannerRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private GamesBannerRepository _repo;
        private Mock<DbSet<GamesBanner>> _bannerSetMock;
        private List<GamesBanner> _bannerData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _bannerSetMock = new Mock<DbSet<GamesBanner>>();
            _bannerData = new List<GamesBanner>
            {
                new GamesBanner { Id = 1, Title = "Banner1" },
                new GamesBanner { Id = 2, Title = "Banner2" }
            };
            var queryable = _bannerData.AsQueryable();
            _bannerSetMock.As<IQueryable<GamesBanner>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _bannerSetMock.As<IQueryable<GamesBanner>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _bannerSetMock.As<IQueryable<GamesBanner>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _bannerSetMock.As<IQueryable<GamesBanner>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Games_Banner).Returns(_bannerSetMock.Object);
            _repo = new GamesBannerRepository(_dbContextMock.Object);
        }

        [Test]
        public void GetBannerById_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _bannerSetMock.Setup(x => x.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<GamesBanner, bool>>>())).Returns((GamesBanner)null);
            // Act
            var result = _repo.GetBannerById(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetBannerById_ReturnsBanner_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _bannerData.First(b => b.Id == foundId);
            _bannerSetMock.Setup(x => x.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<GamesBanner, bool>>>())).Returns(expected);
            // Act
            var result = _repo.GetBannerById(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Title, result.Title);
        }

        [Test]
        public void GetAllBanners_ReturnsAll()
        {
            // Act
            var result = _repo.GetAllBanners();
            // Assert
            Assert.AreEqual(_bannerData.Count, result.Count());
        }
    }
}
