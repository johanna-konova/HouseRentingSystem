namespace HouseRentingSystem.Core.Constants
{
    public static class MessageConstants
	{
		public const string RequiredMessage = "The {0} field is required.";

		public const string InvalidStringLength = "The {0} field must be between {2} and {1} characters long.";

        public const string InvalidUrlFormat = "The {0} field is not valid URL format.";

        public const string InvalidPricePerMonthRange = "The {0} field must be a positive number and less than {2} leva.";

		public const string AlreadyAgent = "You are already an agent.";

        public const string AgentIsNotAllowedToRent = "Agent is not allowed to rent properties.";

		public const string AlreadyRented = "The property is already rented.";

        public const string MustBeAgent = "You must be an agent to add new house.";
        
        public const string MustBeHouseCreator = "You must be the agent and creator of this house to access this page.";

        public const string PhoneExists = "Phone number already exists. Enter another one.";

        public const string HasRents = "You should have no rents to become an agent.";

        public const string NonExistentCategory = "The category does not exist.";

        public const string NonExistentPage = "The page does not exist.";
    }
}
