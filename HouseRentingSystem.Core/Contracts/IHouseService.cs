using HouseRentingSystem.Core.Models.Home;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> GetLastThreeAsync();
        Task<bool> hasRentAsync(Guid userId);
    }
}
