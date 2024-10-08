using HouseRentingSystem.Core.Models.Admin;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}
