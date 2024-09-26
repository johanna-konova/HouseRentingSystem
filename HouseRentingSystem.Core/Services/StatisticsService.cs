using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistics;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseRentingSystem.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repository;

        public StatisticsService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<HousesStatisticModel> GetHousesStatisticAsync()
            => new HousesStatisticModel()
            {
                TotalHousesCount = await repository
                    .AllAsNoTracking<House>()
                    .CountAsync(h => h.IsActive),
                RentedHousesCount = await repository
                    .AllAsNoTracking<House>()
                    .CountAsync(h => h.IsActive && h.RenterId != null),
            };
    }
}
