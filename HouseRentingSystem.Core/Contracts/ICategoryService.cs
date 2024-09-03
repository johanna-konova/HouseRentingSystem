using HouseRentingSystem.Core.Models.Houses;

namespace HouseRentingSystem.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<HouseCategoryOptionModel>> GetAllAsync();
        Task<bool> HasCategoryWithGivenId(int id);
        Task<IEnumerable<string>> GetCategoriesNamesAsync();
	}
}
