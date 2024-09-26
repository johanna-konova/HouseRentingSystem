using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Models.Home
{
    public class IndexViewModel : IHouseModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public string ImageUrl { get; init; } = string.Empty;

    }
}
