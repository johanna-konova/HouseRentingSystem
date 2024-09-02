using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository _repository)
        {
            repository = _repository;
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

            public async Task<bool> HasRentAsync(Guid userId)
            => await repository
                .AllAsNoTracking<House>()
                .AnyAsync(h => h.RenterId == userId);
    }
}
