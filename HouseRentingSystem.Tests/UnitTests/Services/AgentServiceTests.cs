using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using MockQueryable;
using Moq;

namespace HouseRentingSystem.Tests.UnitTests.Services
{
    public class AgentServiceTests
    {
        private Mock<IRepository> mockedRepository;
        private IAgentService agentService;
        private Agent agent;
        private Guid userId;
        private BecomeAgentFormModel model;

        [SetUp]
        public void SetUp()
        {
            mockedRepository = new Mock<IRepository>();
            agentService = new AgentService(mockedRepository.Object);
        }

        private void SetUpAgentAndMockedRepository()
        {
            agent = new Agent()
            {
                Id = Guid.NewGuid(),
                PhoneNumber = "+359888888887",
                UserId = Guid.NewGuid(),
            };

            mockedRepository
                .Setup(r => r.AllAsNoTracking<Agent>())
                .Returns(new List<Agent>() { agent }.AsQueryable().BuildMock());
        }

        private void SetUpUserIdBecomeAgentFormModel()
        {
            userId = Guid.NewGuid();
            model = new BecomeAgentFormModel
            {
                PhoneNumber = "123456789"
            };
        }

        [Test]
        public async Task GetAgentIdAsync_ShouldReturnAgentId_WhenAgentExists()
        {
            //Arrange
            SetUpAgentAndMockedRepository();

            // Act
            var result = await agentService.GetAgentIdAsync(agent.UserId);

            // Assert
            Assert.That(agent.Id, Is.EqualTo(result));
        }

        [Test]
        public async Task GetAgentIdAsync_ShouldReturnNull_WhenAgentDoesNotExist()
        {
            //Arrange
            SetUpAgentAndMockedRepository();

            // Act
            var result = await agentService.GetAgentIdAsync(agent.Id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task HasAgentWithGivenPhoneNumberAsync_ShouldReturnTrue_WhenAgentWithGivenPhoneNumberExists()
        {
            //Arrange
            SetUpAgentAndMockedRepository();

            // Act
            var result = await agentService.HasAgentWithGivenPhoneNumberAsync(agent.PhoneNumber);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasAgentWithGivenPhoneNumberAsync_ShouldReturnFalse_WhenAgentWithGivenPhoneNumberNotExist()
        {
            //Arrange
            SetUpAgentAndMockedRepository();

            // Act
            var result = await agentService.HasAgentWithGivenPhoneNumberAsync("+3598888888878");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsAgentAsync_ShouldReturnTrue_WhenUserIsAgent()
        {
            //Arrange
            SetUpAgentAndMockedRepository();

            // Act
            var result = await agentService.IsAgentAsync(agent.UserId);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsAgentAsync_ShouldReturnFalse_WhenUserIsNotAgent()
        {
            //Arrange
            SetUpAgentAndMockedRepository();

            // Act
            var result = await agentService.IsAgentAsync(agent.Id);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateAsync_ShouldCallAddAsyncAndSaveChangesAsyncOnce()
        {
            // Arrange
            SetUpUserIdBecomeAgentFormModel();

            // Act
            await agentService.CreateAsync(userId, model);

            // Assert
            mockedRepository.Verify(r => r.AddAsync(It.Is<Agent>(a => a.UserId == userId && a.PhoneNumber == model.PhoneNumber)), Times.Once);
            mockedRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task CreateAsync_ShouldAddAgentToList()
        {
            // Arrange
            SetUpUserIdBecomeAgentFormModel();

            var agents = new List<Agent>();

            mockedRepository
                .Setup(r => r.AddAsync(It.IsAny<Agent>()))
                .Callback<Agent>(agents.Add);

            // Act
            await agentService.CreateAsync(userId, model);

            // Assert
            Assert.That(agents.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task CreateAsync_ShouldAddAgentWithCorrectProperties()
        {
            // Arrange
            SetUpUserIdBecomeAgentFormModel();

            var agents = new List<Agent>();

            mockedRepository
                .Setup(r => r.AddAsync(It.IsAny<Agent>()))
                .Callback<Agent>(agents.Add);

            // Act
            await agentService.CreateAsync(userId, model);

            // Assert
            var addedAgent = agents.First();
            Assert.That(addedAgent.UserId, Is.EqualTo(userId));
            Assert.That(addedAgent.PhoneNumber, Is.EqualTo(model.PhoneNumber));
        }

    }
}
