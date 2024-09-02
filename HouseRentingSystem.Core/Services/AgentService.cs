using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agents;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

		public async Task CreateAsync(Guid userId, BecomeAgentFormModel model)
		{
            var newAgent = new Agent()
			{
				PhoneNumber = model.PhoneNumber,
                UserId = userId,
			};

			await repository.AddAsync(newAgent);
            await repository.SaveChangesAsync();
		}

		public async Task<bool> hasAgentWithGivenPhoneNumberAsync(string phoneNumber)
            => await repository
                .AllAsNoTracking<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

        public async Task<bool> IsAgentAsync(Guid userId)
            => await repository
                .AllAsNoTracking<Agent>()
                .AnyAsync(a => a.UserId == userId);
    }
}
