﻿namespace HouseRentingSystem.Core.Constants
{
    public static class MessageConstants
	{
		public const string RequiredMessage = "The {0} field is required.";

		public const string InvalidStringLength = "The {0} field must be between {2} and {1} characters long.";

        public const string InvalidUrlFormat = "The {0} field is not valid URL format.";

        public const string InvalidPricePerMonthRange = "The {0} field must be a positive number and less than {2} leva.";

		public const string AlreadyAgent = "You are already an agent.";

        public const string MustBeAgent = "You must be an agent to add new house.";

        public const string PhoneExists = "Phone number already exists. Enter another one.";

        public const string HasRents = "You should have no rents to become an agent.";

        public const string NonExistentCategory = "Category does not exist.";
    }
}
