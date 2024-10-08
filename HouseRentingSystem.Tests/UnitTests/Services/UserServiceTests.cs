using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using HouseRentingSystem.Tests.Mocks;
using MockQueryable;
using Moq;

namespace HouseRentingSystem.Tests.UnitTests.Services
{
    public class UserServiceTests
    {
        private Mock<IRepository> mockedRepository;
        private IUserService userService;
        private List<ApplicationUser> users;
        private List<Agent> agents;

        [SetUp]
        public void Setup()
        {
            users = new List<ApplicationUser>()
            {
                new ApplicationUser() { Email = "user@mail.com" },
                new ApplicationUser() { Email = "agent@mail.com" },
                new ApplicationUser() { Email = "renter@mail.com" },
            };

            agents = new List<Agent>()
            {
                new Agent()
                {
                    UserId = users[1].Id,
                    User = users[1],
                },
            };

            mockedRepository = new Mock<IRepository>();
            
            userService = new UserService(
                mockedRepository.Object,
                IMapperMock.Instance);

            mockedRepository
                .Setup(r => r.AllAsNoTracking<Agent>())
                .Returns(agents.AsQueryable().BuildMock());

            mockedRepository
                .Setup(r => r.AllAsNoTracking<ApplicationUser>())
                .Returns(users.AsQueryable().BuildMock());
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnCorrectNumberOfUsers_WhenAgentsAndUsersExist()
        {
            // Act
            var result = await userService.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetAllAsync_ShouldIncludeAgentsInResults()
        {
            // Act
            var result = await userService.GetAllAsync();

            // Assert
            var agentViewModel = result.FirstOrDefault(u => u.Email == users[1].Email);

            Assert.That(agentViewModel, Is.Not.Null);
            Assert.That(agentViewModel.FullName, Is.EqualTo($"{users[1].FirstName} {users[1].LastName}"));
            Assert.That(agentViewModel.PhoneNumber, Is.EqualTo(agents[0].PhoneNumber));
        }

        [Test]
        public async Task GetAllAsync_ShouldIncludeNonAgentUsersInResults()
        {
            // Act
            var result = await userService.GetAllAsync();

            // Assert
            var regularUserViewModel = result.FirstOrDefault(u => u.Email == users[0].Email);

            Assert.That(regularUserViewModel, Is.Not.Null);
            Assert.That(regularUserViewModel.FullName, Is.EqualTo($"{users[0].FirstName} {users[0].LastName}"));
            Assert.That(regularUserViewModel.PhoneNumber, Is.Null);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExist()
        {
            // Arrange
            mockedRepository
                .Setup(r => r.AllAsNoTracking<Agent>())
                .Returns(new List<Agent>().AsQueryable().BuildMock());

            mockedRepository
                .Setup(r => r.AllAsNoTracking<ApplicationUser>())
                .Returns(new List<ApplicationUser>().AsQueryable().BuildMock());

            // Act
            var result = await userService.GetAllAsync();

            // Assert
            Assert.That(result, Is.Empty);
        }
    }
}
