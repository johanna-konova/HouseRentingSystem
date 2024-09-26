namespace HouseRentingSystem.Core.Constants
{
    public static class ModelsMessagesConstants
    {
        public const string RequiredMessage = "The {0} is required.";
        public const string InvalidPasswordLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string MismatchedPasswords = "The password and confirmation password do not match.";
        public const string InvalidStringLength = "The {0} must be between {2} and {1} characters long.";
        public const string InvalidPhoneNumberFormat = "The {0} is not valid format. Example: 00359885104005";
        public const string InvalidUrlFormat = "The {0} is not valid URL format.";
        public const string InvalidPriceRange = "The {0} must be a positive number and less than {2} leva.";
        public const string NonExistentCategory = "The category does not exist.";
    }
}
