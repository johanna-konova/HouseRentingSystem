using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.ModelsConstants;
using static HouseRentingSystem.Core.Constants.ModelsMessagesConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace HouseRentingSystem.Core.Models.User
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; } = string.Empty;

        [Required]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = InvalidStringLength)]
        [Display(Name = "First name")]
        public string FirstName { get; init; } = string.Empty;

        [Required]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength,
            ErrorMessage = InvalidStringLength)]
        [Display(Name = "Last name")]
        public string LastName { get; init; } = string.Empty;

        [Required]
        [StringLength(PasswordMaxLength,
            MinimumLength = PasswordMinLength,
            ErrorMessage = InvalidPasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; init; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = MismatchedPasswords)]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
