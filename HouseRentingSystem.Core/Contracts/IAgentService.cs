using HouseRentingSystem.Core.Models.Agents;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> IsAgentAsync(Guid userId);
        Task<bool> hasAgentWithGivenPhoneNumberAsync(string phoneNumber);
        Task CreateAsync(Guid userId, BecomeAgentFormModel model);
    }
}
