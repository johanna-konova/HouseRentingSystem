using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            RentedHouses = new HashSet<House>();
        }

        public IEnumerable<House> RentedHouses { get; init; }
    }
}
