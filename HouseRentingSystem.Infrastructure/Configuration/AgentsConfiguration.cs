using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Configuration
{
    internal class AgentsConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(GenerateAgents());
        }

        private IEnumerable<Agent> GenerateAgents()
        {
            var agents = new HashSet<Agent>();

            Agent agent = new Agent()
            {
                Id = Guid.Parse("bae99276-1865-4c63-899c-093d3b85f014"),
                PhoneNumber = "+359888888888",
                UserId = Guid.Parse("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"),

            };
            agents.Add(agent);

            return agents;
        }
    }
}
