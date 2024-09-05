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
        Task<bool> HasHouseWithGivenIdAsync(Guid id);
        Task<HouseDetailsViewModel?> GetDetailsAsync(Guid id);
        Task<HouseDeleteViewModel?> GetDetailsForDeleteFormAsync(Guid id);
        Task<bool> IsAgentHouseCreatorAsync(Guid houseId, Guid userId);
        Task<int> GetHouseCategoryIdAsync(Guid houseId);
        Task EditAsync(Guid houseId, HouseFormModel model);
        Task DeleteAsync(Guid houseId);
    }
}
