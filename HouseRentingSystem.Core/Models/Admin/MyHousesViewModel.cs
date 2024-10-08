using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Models.Admin
{
    public class MyHousesViewModel
    {
        public IEnumerable<HouseViewModel> ManageredHouses { get; init; }
            = new HashSet<HouseViewModel>();
        public IEnumerable<HouseViewModel> RentedHouses { get; init; }
            = new HashSet<HouseViewModel>();
    }
}
