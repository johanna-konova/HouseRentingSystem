using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Models;

namespace System.Linq
{
    public static class IQuerableHouseExtensions
    {
        public static IQueryable<HouseViewModel> ProjectToHouseViewModel(this IQueryable<House> housesAsQuery)
            => housesAsQuery
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                });
    }
}
