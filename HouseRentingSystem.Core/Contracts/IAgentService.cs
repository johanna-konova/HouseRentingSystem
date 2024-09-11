using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
		Task<Guid?> GetAgentIdAsync(Guid userId);
        Task<bool> IsAgentAsync(Guid userId);
        Task<bool> HasAgentWithGivenPhoneNumberAsync(string phoneNumber);
        Task CreateAsync(Guid userId, BecomeAgentFormModel model);
	}
}
