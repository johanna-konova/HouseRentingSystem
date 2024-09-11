namespace HouseRentingSystem.Core.Constants
{
    public static class MessageConstants
	{
		public const string AlreadyAgent = "You are already an agent.";
        public const string AgentIsNotAllowedToRent = "Agent is not allowed to rent properties.";
        public const string AlreadyRented = "The property is already rented.";
        public const string OnlyPropertyRenterIsAllowedToLeaveIt = "Only the renter of the property is allowed to leave it.";
        public const string MustBeAgent = "You must be an agent to add new house.";
        public const string MustBeHouseCreator = "You must be the agent and creator of this house to access this page.";
        public const string PhoneExists = "Phone number already exists. Enter another one.";
        public const string HasRents = "You should have no rents to become an agent.";
        public const string NonExistentPage = "The page does not exist.";
    }
}
