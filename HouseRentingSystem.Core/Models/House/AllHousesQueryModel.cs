using HouseRentingSystem.Core.Models.House.Enums;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class AllHousesQueryModel
    {
		public string Category { get; init; } = string.Empty;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = string.Empty;
        public Sorting Sorting { get; init; }

        [Display(Name = "Houses per pages")]
        public int HousesPerPage { get; init; } = 3;
        public int CurrentPage { get; init; } = 1;
        public int TotalHousesCount { get; set; }
        public IEnumerable<HouseViewModel> Houses { get; set; }
            = new HashSet<HouseViewModel>();
		public IEnumerable<string> Categories { get; set; }
            = new HashSet<string>();
	}
}
