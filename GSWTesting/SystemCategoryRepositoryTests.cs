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
    public class SystemCategoryRepositoryTests
    {
        private Mock<DBContext> _dbContextMock;
        private SystemCategoryRepository _repo;
        private Mock<DbSet<SystemCategory>> _categorySetMock;
        private List<SystemCategory> _categoryData;

        [SetUp]
        public void SetUp()
        {
            _dbContextMock = new Mock<DBContext>();
            _categorySetMock = new Mock<DbSet<SystemCategory>>();
            _categoryData = new List<SystemCategory>
            {
                new SystemCategory { ID = 1, CategoryName = "Action" },
                new SystemCategory { ID = 2, CategoryName = "Adventure" }
            };
            var queryable = _categoryData.AsQueryable();
            _categorySetMock.As<IQueryable<SystemCategory>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _categorySetMock.As<IQueryable<SystemCategory>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _categorySetMock.As<IQueryable<SystemCategory>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _categorySetMock.As<IQueryable<SystemCategory>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            _dbContextMock.Setup(x => x.System_Categories).Returns(_categorySetMock.Object);
            _repo = new SystemCategoryRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int notFoundId = 999;
            _categorySetMock.Setup(x => x.FindAsync(notFoundId)).ReturnsAsync((SystemCategory)null);
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
            Assert.AreEqual(expected.CategoryName, result.CategoryName);
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
