using HouseRentingSystem.Infrastructure.Models;

namespace HouseRentingSystem.Tests.UnitTests
{
    public static class DataGenerator
    {
        public static List<ApplicationUser> GenerateUsers()
            => new List<ApplicationUser>()
            {
                new ApplicationUser(),
                new ApplicationUser(),
                new ApplicationUser(),
                new ApplicationUser(),
            };

        public static List<Agent> GenerateAgents(List<ApplicationUser> users)
            => new List<Agent>()
            {
                new Agent() { UserId = users[1].Id, User = users[1] },
                new Agent() { UserId = users[3].Id, User = users[3] },
            };

        public static List<Category> GenerateCategories()
            => new List<Category>()
            {
            new Category { Id = 1, Name = "Hotel" },
            new Category { Id = 2, Name = "House" },
            new Category { Id = 3, Name = "Apartment" },
            };

        public static List<House> GenerateHouses(
            List<Agent> agents,
            ApplicationUser renter)
            => new List<House>()
            {
                new House()
                {
                    Title = "First Test House",
                    Address = "Test, 201 Test",
                    Description = "This is a test description. This is a test description. This is a test description.",
                    ImageUrl = "https://www.bhg.com/thmb/0Fg0imFSA6HVZMS2DFWPvjbYDoQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg",
                    AgentId = agents[0].Id,
                    Agent = agents[0],
                },

                new House()
                {
                    Title = "Second Test House",
                    Address = "Test, 204 Test",
                    Description = "This is another test description. This is another test description.",
                    ImageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149",
                    AgentId = agents[1].Id,
                    Agent = agents[1],
                    RenterId = renter.Id,
                    Renter = renter,
                },

                new House()
                {
                    Title = "Third Test House",
                    Address = "Test, 209 Test",
                    Description = "This is another test description. This is another test description.",
                    ImageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149",
                    AgentId = agents[0].Id,
                    Agent = agents[0],
                },

                new House()
                {
                    Title = "Fourth Test House",
                    Address = "Test, 406 Test",
                    Description = "This is a fourth test description. A perfect home for a growing family.",
                    ImageUrl = "https://images.adsttc.com/media/images/6077/eb82/f91c/81f2/1952/000e/newsletter/JES-2687.JPG?1618490086",
                    AgentId = agents[1].Id,
                    Agent = agents[1],
                    RenterId = renter.Id,
                    Renter = renter,
                },

                new House()
                {
                    Title = "Fifth Test House",
                    Address = "Test, 507 Test",
                    Description = "This is a fifth test description. Featuring a beautiful garden and spacious interior.",
                    ImageUrl = "https://images.adsttc.com/media/images/5f6c/ae24/63c0/1700/0c00/0345/newsletter/The_Gable_House_Co_Lab_design_studio__8_.jpg?1600884516",
                    AgentId = agents[0].Id,
                    Agent = agents[0],
                    RenterId = renter.Id, Renter = renter,
                },
            };
    }
}
