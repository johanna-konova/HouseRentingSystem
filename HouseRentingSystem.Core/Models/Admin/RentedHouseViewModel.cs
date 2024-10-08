namespace HouseRentingSystem.Core.Models.Admin
{
    public class RentedHouseViewModel
    {
        public string Title { get; init; } = string.Empty;
        public string ImageUrl { get; init; } = string.Empty;
        public string AgentFullName { get; init; } = string.Empty;
        public string AgentEmail { get; init; } = string.Empty;
        public string RenterFullName { get; init; } = string.Empty;
        public string RenterEmail { get; init; } = string.Empty;
    }
}
