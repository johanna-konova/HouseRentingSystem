using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Home;
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

            public async Task<bool> hasRentAsync(Guid userId)
            => await repository
                .AllAsNoTracking<House>()
                .AnyAsync(h => h.RenterId == userId);
    }
}
