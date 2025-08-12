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
    public class GamesDiscountRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private GamesDiscountRepository _repo;
        private Mock<DbSet<GamesDiscount>> _discountSetMock;
        private List<GamesDiscount> _discountData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _discountSetMock = new Mock<DbSet<GamesDiscount>>();
            _discountData = new List<GamesDiscount>
            {
                new GamesDiscount { Id = 1, Code = "DISC10", Value = 10 },
                new GamesDiscount { Id = 2, Code = "DISC20", Value = 20 }
            };
            var queryable = _discountData.AsQueryable();
            _discountSetMock.As<IQueryable<GamesDiscount>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _discountSetMock.As<IQueryable<GamesDiscount>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _discountSetMock.As<IQueryable<GamesDiscount>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _discountSetMock.As<IQueryable<GamesDiscount>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.Games_Discount).Returns(_discountSetMock.Object);
            _repo = new GamesDiscountRepository(_dbContextMock.Object);
        }

        [Test]
        public void Get_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _discountSetMock.Setup(x => x.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<GamesDiscount, bool>>>())).Returns((GamesDiscount)null);
            // Act
            var result = _repo.Get(notFoundId);
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Get_ReturnsDiscount_WhenFound()
        {
            // Arrange
            int foundId = 1;
            var expected = _discountData.First(d => d.Id == foundId);
            _discountSetMock.Setup(x => x.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<GamesDiscount, bool>>>())).Returns(expected);
            // Act
            var result = _repo.Get(foundId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Code, result.Code);
        }

        [Test]
        public void GetAll_ReturnsAll()
        {
            // Act
            var result = _repo.GetAll();
            // Assert
            Assert.AreEqual(_discountData.Count, result.Count());
        }
    }
}
