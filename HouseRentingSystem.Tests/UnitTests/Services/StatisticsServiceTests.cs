using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistics;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using MockQueryable;
using Moq;

using static HouseRentingSystem.Tests.UnitTests.DataGenerator;

namespace HouseRentingSystem.Tests.UnitTests.Services
{
    public class StatisticsServiceTests
    {
        private Mock<IRepository> mockedRepository;
        private IStatisticsService statisticsService;
        public List<House> houses;

        [SetUp]
        public void SetUp()
        {
            mockedRepository = new Mock<IRepository>();
            statisticsService = new StatisticsService(mockedRepository.Object);

            houses = new List<House>()
            {
                new House() { RenterId = Guid.NewGuid() },
                new House(),
                new House() { RenterId = Guid.NewGuid() },
            };

            mockedRepository
                .Setup(r => r.AllAsNoTracking<House>())
                .Returns(houses.AsQueryable().BuildMock());
        }

        [Test]
        public async Task GetHousesStatisticAsync_SholdRetrnNonNullResult()
        {
            // Act
            var result = await statisticsService.GetHousesStatisticAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetHousesStatisticAsync_SholdRetrnCorrectHousesCounts()
        {
            //Assert
            houses[0].IsActive = false;

            // Act
            var result = await statisticsService.GetHousesStatisticAsync();

            // Assert
            Assert.That(result.TotalHousesCount, Is.EqualTo(2));
            Assert.That(result.RentedHousesCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetHousesStatisticAsync_SholdRetrnHousesStatisticModel()
        {
            // Act
            var result = await statisticsService.GetHousesStatisticAsync();

            // Assert
            Assert.That(result, Is.InstanceOf<HousesStatisticModel>());
        }

        [Test]
        public async Task GetHousesStatisticAsync_ShouldReturnZeroCounts_WhenNoActiveHouses()
        {
            // Arrange
            mockedRepository
                .Setup(r => r.AllAsNoTracking<House>())
                .Returns(new List<House>().AsQueryable().BuildMock());

            // Act
            var result = await statisticsService.GetHousesStatisticAsync();

            // Assert
            Assert.That(result.TotalHousesCount, Is.EqualTo(0));
            Assert.That(result.RentedHousesCount, Is.EqualTo(0));
        }

        [Test]
        public async Task GetHousesStatisticAsync_ShouldHandleAllHousesInactive()
        {
            // Arrange
            houses.ForEach(h => h.IsActive = false);

            // Act
            var result = await statisticsService.GetHousesStatisticAsync();

            // Assert
            Assert.That(result.TotalHousesCount, Is.EqualTo(0));
            Assert.That(result.RentedHousesCount, Is.EqualTo(0));
        }
    }
}
