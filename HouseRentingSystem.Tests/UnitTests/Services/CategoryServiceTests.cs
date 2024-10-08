using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using HouseRentingSystem.Tests.Mocks;
using MockQueryable;
using Moq;
using static HouseRentingSystem.Tests.UnitTests.DataGenerator;

namespace HouseRentingSystem.Tests.UnitTests.Services
{
    public class CategoryServiceTests
    {
        private ICategoryService categoryService;
        private List<Category> categories;

        [SetUp]
        public void SetUp()
        {
            var mockedRepository = new Mock<IRepository>();

            categoryService = new CategoryService(mockedRepository.Object, IMapperMock.Instance);

            categories = GenerateCategories();

            mockedRepository
                .Setup(r => r.AllAsNoTracking<Category>())
                .Returns(categories.AsQueryable().BuildMock());
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnNonNullResult()
        {
            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnCorrectNumberOfCategories()
        {
            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnCategoriesWithCorrectNames()
        {
            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.That(result.First().Id, Is.EqualTo(categories[0].Id));
            Assert.That(result.Last().Id, Is.EqualTo(categories[2].Id));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnCorrectCategoryType()
        {
            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.That(result, Is.All.InstanceOf<HouseCategoryOptionModel>());
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnEmptyCollection_WhenNoCategoriesExist()
        {
            // Arrange
            categories.Clear();

            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetCategoriesNamesAsync_ShouldReturnNonNullResult()
        {
            // Act
            var result = await categoryService.GetCategoriesNamesAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetCategoriesNamesAsync_ShouldReturnCorrectNumberOfCategoryNames()
        {
            // Act
            var result = await categoryService.GetCategoriesNamesAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(categories.Count));
        }

        [Test]
        public async Task GetCategoriesNamesAsync_ShouldReturnCorrectCategoryNames()
        {
            // Act
            var result = await categoryService.GetCategoriesNamesAsync();

            // Assert
            Assert.That(result.First, Is.EqualTo(categories[0].Name));
            Assert.That(result.Last, Is.EqualTo(categories[2].Name));
        }

        [Test]
        public async Task GetCategoriesNamesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            categories.Clear();

            // Act
            var result = await categoryService.GetCategoriesNamesAsync();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task HasCategoryWithGivenIdAsync_ShouldReturnTrue_WhenCategoryWithGivenIdExists()
        {
            // Act
            var result = await categoryService.HasCategoryWithGivenId(1);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasCategoryWithGivenIdAsync_ShouldReturnFalse_WhenCategoryWithGivenIdNotExists()
        {
            // Act
            var result = await categoryService.HasCategoryWithGivenId(5);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
