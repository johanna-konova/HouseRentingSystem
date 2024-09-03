namespace HouseRentingSystem.Core.Models.House
{
	public class HouseViewModel
	{
		public Guid Id { get; init; }
		public string Title { get; init; } = string.Empty;
		public string Address { get; init; } = string.Empty;
		public string ImageUrl { get; init; } = string.Empty;
		public decimal PricePerMonth { get; init; }
		public bool IsRented { get; init; }
	}
}
