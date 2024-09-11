using HouseRentingSystem.Core.Models.Houses;

namespace HouseRentingSystem.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<HouseCategoryOptionModel>> GetAllAsync();
        Task<IEnumerable<string>> GetCategoriesNamesAsync();
        Task<bool> HasCategoryWithGivenId(int id);
	}
}
