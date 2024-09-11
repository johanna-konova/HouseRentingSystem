using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> GetLastThreeAsync();
        Task<IEnumerable<HouseViewModel>> GetManagedByAgentIdAsync(Guid agentId);
        Task<IEnumerable<HouseViewModel>> GetRentedByUserIdAsync(Guid userId);
        Task<AllHousesQueryModel> GetAllAsync(AllHousesQueryModel model);
        Task<HouseDetailsViewModel?> GetDetailsAsync(Guid id);
        Task<HouseDeleteViewModel?> GetDetailsForDeleteFormAsync(Guid id);
        Task<int> GetHouseCategoryIdAsync(Guid houseId);
        Task<bool> HasHouseWithGivenIdAsync(Guid id);
        Task<bool> IsAgentHouseCreatorAsync(Guid houseId, Guid userId);
        Task<bool> HasRentAsync(Guid userId);
        Task<bool> IsRented(Guid houseId);
        Task<bool> IsRentedByUserWithGivenId(Guid houseId, Guid userId);
        Task<Guid> CreateAsync(HouseFormModel model, Guid agentId);
        Task EditAsync(Guid houseId, HouseFormModel model);
        Task DeleteAsync(Guid houseId);
        Task RentAsync(Guid houseId, Guid userId);
        Task LeaveAsync(Guid houseId);
    }
}
