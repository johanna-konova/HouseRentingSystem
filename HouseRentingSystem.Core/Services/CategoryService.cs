using AutoMapper;
using AutoMapper.QueryableExtensions;
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
		private readonly IMapper mapper;

        public CategoryService(
            IRepository _repository,
			IMapper _mapper)
        {
            repository = _repository;
			mapper = _mapper;
        }

        public async Task<IEnumerable<HouseCategoryOptionModel>> GetAllAsync()
			=> await repository
				.AllAsNoTracking<Category>()
                .ProjectTo<HouseCategoryOptionModel>(mapper.ConfigurationProvider)
                .ToListAsync();

		public async Task<IEnumerable<string>> GetCategoriesNamesAsync()
			=> await repository
				.AllAsNoTracking<Category>()
				.Select(c => c.Name)
				.ToListAsync();

		public async Task<bool> HasCategoryWithGivenIdAsync(int id)
			=> await repository
				.AllAsNoTracking<Category>()
				.AnyAsync(c => c.Id == id);
	}
}
