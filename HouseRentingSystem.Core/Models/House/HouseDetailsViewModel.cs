namespace HouseRentingSystem.Core.Models.House
{
	public class HouseDetailsViewModel : HouseViewModel
	{
		public string Description { get; init; } = string.Empty;
		public  string Category { get; init; } = string.Empty;
		public HouseAgentInfoModel Agent { get; init; } = null!;
	}
}
