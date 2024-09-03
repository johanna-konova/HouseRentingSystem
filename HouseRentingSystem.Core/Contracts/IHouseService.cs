using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> GetLastThreeAsync();
        Task<bool> HasRentAsync(Guid userId);
        Task<Guid> CreateAsync(HouseFormModel model, Guid agentId);
        Task<AllHousesQueryModel> GetAllAsync(AllHousesQueryModel model);
        Task<IEnumerable<HouseViewModel>> GetManagedByAgentIdAsync(Guid agentId);
        Task<IEnumerable<HouseViewModel>> GetRentedByUserIdAsync(Guid userId);
    }
}
