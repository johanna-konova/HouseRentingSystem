using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> IsAgentAsync(Guid userId);
        Task<bool> HasAgentWithGivenPhoneNumberAsync(string phoneNumber);
        Task CreateAsync(Guid userId, BecomeAgentFormModel model);
		Task<Guid?> GetAgentIdAsync(Guid userId);
	}
}
