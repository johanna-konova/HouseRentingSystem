using System.ComponentModel.DataAnnotations;

using static HouseRentingSystem.Core.Constants.ModelsMessagesConstants;
using static HouseRentingSystem.Infrastructure.DataConstants.Agent;

namespace HouseRentingSystem.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = InvalidStringLength)]
        [Phone(ErrorMessage = InvalidPhoneNumberFormat)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
