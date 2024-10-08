using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Admin;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
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
    public class HouseServiceTests
    {
        private Mock<IRepository> mockedRepository;
        private IHouseService houseService;
        private List<Agent> agents;
        private ApplicationUser renter;
        public List<House> houses;

        [SetUp]
        public void SetUp()
        {
            mockedRepository = new Mock<IRepository>();
            houseService = new HouseService(
                mockedRepository.Object,
                null, // TODO
                IMapperMock.Instance);

            var users = GenerateUsers();
            agents = GenerateAgents(users);
            renter = new ApplicationUser();

            houses = GenerateHouses(agents, renter);

            mockedRepository
                .Setup(r => r.AllAsNoTracking<House>())
                .Returns(houses.AsQueryable().BuildMock());
        }

        [Test]
        public async Task GetLastThreeAsync_ShouldReturnInstanceOfIndexViewModel()
        {
            // Act
            var result = await houseService.GetLastThreeAsync();

            // Assert
            Assert.That(result, Is.All.InstanceOf<IndexViewModel>());
        }

        [Test]
        public async Task GetLastThreeAsync_ShouldReturnCorrectHouses_WhenThereAreExactlyThreeActiveHouses()
        {
            // Arrange
            houses.RemoveAt(4);
            houses.RemoveAt(3);

            // Act
            var result = await houseService.GetLastThreeAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.First().Id, Is.EqualTo(houses[2].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[0].Id));
        }

        [Test]
        public async Task GetLastThreeAsync_ShouldReturnCorrectHouses_WhenThereAreMoreThanThreeActiveHouses()
        {
            // Act
            var result = await houseService.GetLastThreeAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.First().Id, Is.EqualTo(houses[4].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[2].Id));
        }

        [Test]
        public async Task GetLastThreeAsync_ShouldReturnCorrectHouses_WhenThereAreLessThanThreeActiveHouses()
        {
            // Arrange
            houses[0].IsActive = false;
            houses[2].IsActive = false;
            houses[4].IsActive = false;

            // Act
            var result = await houseService.GetLastThreeAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(houses[3].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[1].Id));
        }

        [Test]
        public async Task GetLastThreeAsync_ShouldReturnEmptyCollction_WhenThereAreNonActiveHouses()
        {
            // Arange
            houses[0].IsActive = false;
            houses[1].IsActive = false;
            houses[2].IsActive = false;
            houses[3].IsActive = false;
            houses[4].IsActive = false;

            // Act
            var result = await houseService.GetLastThreeAsync();

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetLastThreeAsync_ShouldReturnEmptyCollction_WhenThereAreNonHouses()
        {
            // Arange
            houses.Clear();

            // Act
            var result = await houseService.GetLastThreeAsync();

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetManagedByAgentIdAsync_ShouldReturnInstanceOfHouseViewModel()
        {
            // Act
            var result = await houseService.GetManagedByAgentIdAsync(agents[0].Id);

            // Assert
            Assert.That(result, Is.All.InstanceOf<HouseViewModel>());
        }

        [Test]
        public async Task GetManagedByAgentIdAsync_ShouldReturnCorrectMenageredHouses()
        {
            // Act
            var result = await houseService.GetManagedByAgentIdAsync(agents[0].Id);

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.First().Id, Is.EqualTo(houses[0].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[4].Id));
        }

        [Test]
        public async Task GetManagedByAgentIdAsync_ShouldReturnEmptyCollection_WhenThereAreNoManageredHouses()
        {
            // Arrange
            houses[0].AgentId = Guid.NewGuid();
            houses[2].AgentId = Guid.NewGuid();
            houses[4].AgentId = Guid.NewGuid();

            // Act
            var result = await houseService.GetManagedByAgentIdAsync(agents[0].Id);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetManagedByAgentIdAsync_ShouldReturnOnlyActiveManageredHouses()
        {
            // Arrange
            houses[0].IsActive = false;

            // Act
            var result = await houseService.GetManagedByAgentIdAsync(agents[0].Id);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(houses[2].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[4].Id));
        }

        [Test]
        public async Task GetManagedByAgentIdAsync_ShouldReturnEmptyCollection_WhenThereAreNoHouses()
        {
            // Arrange
            houses.Clear();

            // Act
            var housesManageredByFirstAgent = await houseService.GetManagedByAgentIdAsync(agents[0].Id);
            var housesManageredBySecondAgent = await houseService.GetManagedByAgentIdAsync(Guid.NewGuid());

            // Assert
            Assert.That(housesManageredByFirstAgent, Is.Empty);
            Assert.That(housesManageredByFirstAgent.Count, Is.EqualTo(0));

            Assert.That(housesManageredBySecondAgent, Is.Empty);
            Assert.That(housesManageredBySecondAgent.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetRentedByUserIdAsync_ShouldReturnInstanceOfHouseViewModel()
        {
            // Act
            var result = await houseService.GetRentedByUserIdAsync(renter.Id);

            // Assert
            Assert.That(result, Is.All.InstanceOf<HouseViewModel>());
        }

        [Test]
        public async Task GetRentedByUserIdAsync_ShouldReturnCorrectRenteredHouses()
        {
            // Arrange
            houses[3].RenterId = Guid.NewGuid();

            // Act
            var result = await houseService.GetRentedByUserIdAsync(renter.Id);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(houses[1].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[4].Id));
        }

        [Test]
        public async Task GetRentedByUserIdAsync_ShouldReturnEmptyCollection_WhenThereAreNoRenteredHouses()
        {
            // Arrange
            houses[1].RenterId = null;
            houses[3].RenterId = null;
            houses[4].RenterId = null;

            // Act
            var result = await houseService.GetRentedByUserIdAsync(renter.Id);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetRentedByUserIdAsync_ShouldReturnOnlyActiveRenteredHouses()
        {
            // Arrange
            houses[1].IsActive = false;

            // Act
            var result = await houseService.GetRentedByUserIdAsync(renter.Id);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(houses[3].Id));
            Assert.That(result.Last().Id, Is.EqualTo(houses[4].Id));
        }

        [Test]
        public async Task GetRentedByUserIdAsync_ShouldReturnEmptyCollection_WhenThereAreNoHouses()
        {
            // Arrange
            houses.Clear();

            // Act
            var result = await houseService.GetRentedByUserIdAsync(renter.Id);

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetAllRentedAsync_ShouldReturnInstanceOfRentedHouseViewModel()
        {
            // Act
            var result = await houseService.GetAllRentedAsync();

            // Assert
            Assert.That(result, Is.All.InstanceOf<RentedHouseViewModel>());
        }

        [Test]
        public async Task GetAllRentedAsync_ShouldReturnCorrectRenteredHouses()
        {
            // Act
            var result = await houseService.GetAllRentedAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.First().Title, Is.EqualTo(houses[1].Title));
            Assert.That(result.Last().Title, Is.EqualTo(houses[4].Title));
        }

        [Test]
        public async Task GetAllRentedAsync_ShouldReturnEmptyCollection_WhenThereAreNoRenteredHouses()
        {
            // Arrange
            houses[1].RenterId = null;
            houses[3].RenterId = null;
            houses[4].RenterId = null;

            // Act
            var result = await houseService.GetAllRentedAsync();

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetAllRentedAsync_ShouldReturnOnlyActiveRenteredHouses()
        {
            // Arrange
            houses[1].IsActive = false;

            // Act
            var result = await houseService.GetAllRentedAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().Title, Is.EqualTo(houses[3].Title));
            Assert.That(result.Last().Title, Is.EqualTo(houses[4].Title));
        }

        [Test]
        public async Task GetAllRentedAsync_ShouldReturnEmptyCollection_WhenThereAreNoHouses()
        {
            // Arrange
            houses.Clear();

            // Act
            var result = await houseService.GetAllRentedAsync();

            // Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
