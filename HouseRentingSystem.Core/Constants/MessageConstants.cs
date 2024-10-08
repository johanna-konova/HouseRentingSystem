namespace HouseRentingSystem.Core.Constants
{
    public static class MessageConstants
	{
        public const string InvalidLogin = "Invalid login";
        public const string ExternalProviderError = "There was an issue with signing in. Please try again or use another login method.";
        public const string LoadingExternalLoginInfoError = "Failed to load login information. Please try again or use another login method.";

        public const string AlreadyAgent = "You are already an agent.";
        public const string AgentIsNotAllowedToRent = "Agent is not allowed to rent properties.";
        public const string AlreadyRented = "The property is already rented.";
        public const string OnlyPropertyRenterIsAllowedToLeaveIt = "Only the renter of the property is allowed to leave it.";
        public const string MustBeAgent = "You must be an agent to add new house.";
        public const string MustBeAdminOrHouseCreator = "You must be admin or the agent and creator of this house to access this page.";
        public const string PhoneExists = "Phone number already exists. Enter another one.";
        public const string UserHasRents = "You should have no rents to become an agent.";
        public const string NonExistentPage = "The page does not exist.";

        public const string UserBecomeAgent = "You have successfully become an agent.";
        public const string AgentAddedHouse = "You have successfully added a house.";
        public const string AgentEditedHouse = "You have successfully edited a house.";
        public const string AgentDeletedHouse = "You have successfully deleted a house.";
        public const string UserRentedHouse = "You have successfully rented a house.";
        public const string UserLeftHouse = "You have successfully left a house.";
    }
}
