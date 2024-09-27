using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HouseRentingSystem.Infrastructure.Constants.SeedDataConstants;

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
                Id = Guid.Parse(AgentId),
                PhoneNumber = "+359888888888",
                UserId = Guid.Parse(AgentUserId),

            };
            agents.Add(agent);

            return agents;
        }
    }
}
