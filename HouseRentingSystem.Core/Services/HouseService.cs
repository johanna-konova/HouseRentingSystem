using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Models.House.Enums;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;
        private readonly ICategoryService categoryService;

        public HouseService(
            IRepository _repository,
            ICategoryService _categoryService)
        {
            repository = _repository;
            categoryService = _categoryService;
        }

		public async Task<Guid> CreateAsync(HouseFormModel model, Guid agentId)
		{
            var newHouse = new House()
            {
                Title = model.Title,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId,
                AgentId = agentId,
            };

            await repository.AddAsync(newHouse);
            await repository.SaveChangesAsync();

            return newHouse.Id;
		}

		public async Task<AllHousesQueryModel> GetAllAsync(AllHousesQueryModel model)
		{
            var housesQuery = repository.AllAsNoTracking<House>();

            if (!string.IsNullOrEmpty(model.Category))
            {
                housesQuery = housesQuery
                    .Where(h => h.Category.Name == model.Category);
			}

            if (!string.IsNullOrEmpty(model.SearchTerm))
            {
                string wildCard = $"%{model.SearchTerm.ToLower()}%";

                housesQuery = housesQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard)
                             || EF.Functions.Like(h.Description, wildCard)
                             || EF.Functions.Like(h.Address, wildCard));
			}

            housesQuery = model.Sorting switch
            {
                Sorting.Oldest => housesQuery.OrderBy(h => h.CreatedOn),
                Sorting.LowestPrice => housesQuery.OrderBy(h => h.PricePerMonth),
                Sorting.HighestPrice => housesQuery.OrderByDescending(h => h.PricePerMonth),
                Sorting.RentedFirst => housesQuery.OrderBy(h => h.RenterId == null),
                Sorting.NotRentedFirst => housesQuery.OrderBy(h => h.RenterId != null),
                _ => housesQuery.OrderByDescending(h => h.CreatedOn)
			};

            var houses = await housesQuery
                .Skip((model.CurrentPage - 1) * model.HousesPerPage)
                .Take(model.HousesPerPage)
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                })
                .ToListAsync();

            model.TotalHousesCount = housesQuery.Count();
            model.Houses = houses;
            model.Categories = await categoryService.GetCategoriesNamesAsync();

            return model;
		}

        public async Task<HouseDetailsViewModel?> GetByIdAsync(Guid id)
            => await repository
                .AllAsNoTracking<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Category = h.Category.Name,
                    IsRented = h.RenterId != null,
                    Agent = new HouseAgentInfoModel ()
                    {
                        Email = h.Agent.User.Email!,
                        PhoneNumber = h.Agent.PhoneNumber,
                    },
                })
                .FirstOrDefaultAsync();
                

        public async Task<IEnumerable<IndexViewModel>> GetLastThreeAsync()
            => await repository
                .AllAsNoTracking<House>()
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h => new IndexViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                })
                .ToListAsync();

        public async Task<IEnumerable<HouseViewModel>> GetManagedByAgentIdAsync(Guid agentId)
        {
            var housesQuery = repository
                .AllAsNoTracking<House>()
                .Where(h => h.AgentId == agentId);

            return await ProjectToModel(housesQuery);
        }

        public async Task<IEnumerable<HouseViewModel>> GetRentedByUserIdAsync(Guid userId)
        {
            var housesQuery = repository
                .AllAsNoTracking<House>()
                .Where(h => h.RenterId == userId);

            return await ProjectToModel(housesQuery);
        }

        public async Task<bool> HasHouseWithGivenId(Guid id)
            => await repository
                .AllAsNoTracking<House>()
                .AnyAsync(h => h.Id == id && h.IsActive);

        public async Task<bool> HasRentAsync(Guid userId)
            => await repository
                .AllAsNoTracking<House>()
                .AnyAsync(h => h.RenterId == userId);

        private async Task<IEnumerable<HouseViewModel>> ProjectToModel(IQueryable<House> housesQuery)
            => await housesQuery
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                })
                .ToListAsync();
    }
}
