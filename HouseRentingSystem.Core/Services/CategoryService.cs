using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class CategoryService : ICategoryService
	{
		private readonly IRepository repository;

		public CategoryService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<HouseCategoryOptionModel>> GetAllAsync()
			=> await repository
				.AllAsNoTracking<Category>()
				.Select(c => new HouseCategoryOptionModel()
				{
					Id = c.Id,
					Name = c.Name,
				})
				.ToListAsync();

		public async Task<IEnumerable<string>> GetCategoriesNamesAsync()
			=> await repository
				.AllAsNoTracking<Category>()
				.Select(c => c.Name)
				.ToListAsync();

		public async Task<bool> HasCategoryWithGivenId(int id)
			=> await repository
				.AllAsNoTracking<Category>()
				.AnyAsync(c => c.Id == id);
	}
}
