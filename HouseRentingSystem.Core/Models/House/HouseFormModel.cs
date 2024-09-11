using HouseRentingSystem.Core.Models.Houses;
using System.ComponentModel.DataAnnotations;

using static HouseRentingSystem.Core.Constants.ModelsConstants;
using static HouseRentingSystem.Infrastructure.DataConstants.House;

namespace HouseRentingSystem.Core.Models.House
{
	public class HouseFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = InvalidStringLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(
            AddressMaxLength,
            MinimumLength = AddressMinLength,
			ErrorMessage = InvalidStringLength)]
        public string Address { get; init; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
			ErrorMessage = InvalidStringLength)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Url(ErrorMessage = InvalidUrlFormat)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        //[Required(ErrorMessage = RequiredMessage)]
        [Range(
            typeof(decimal),
            PricePerMonthMinValue,
            PricePerMonthMaxValue,
            ErrorMessageResourceType = typeof(Resources.ValidationMessages), ErrorMessageResourceName = "InvalidNumberType")]
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryOptionModel> Categories { get; set; }
            = new HashSet<HouseCategoryOptionModel>();
    }
}
