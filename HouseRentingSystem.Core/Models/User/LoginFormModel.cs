using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.User
{
    public class LoginFormModel
    {
        [Required]
        public string Email { get; init; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; init; } = string.Empty;

        public bool RememberMe { get; init; }

        public string? ReturnUrl { get; init; }
    }
}
