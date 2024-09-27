using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HouseRentingSystem.Infrastructure.Constants.SeedDataConstants;

namespace HouseRentingSystem.Infrastructure.Configuration
{
    internal class ApplicationUsersConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateUsers());
        }

        private IEnumerable<ApplicationUser> GenerateUsers()
        {
            var users = new HashSet<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.Parse(AgentUserId),
                UserName = AgentUserEmail,
                NormalizedUserName = AgentUserEmail.ToUpper(),
                Email = AgentUserEmail,
                NormalizedEmail = AgentUserEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = "XKYK5BIDWLG3ED57QZYQHRLUZMMUVYWS",
                ConcurrencyStamp = "7f3fbb67-83a1-4c8a-9376-77d5bc93e96e",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            
            user.PasswordHash = hasher.HashPassword(user, "agent123");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse(GuestUserId),
                UserName = GuestUserEmail,
                NormalizedUserName = GuestUserEmail.ToUpper(),
                Email = GuestUserEmail,
                NormalizedEmail = GuestUserEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = "JTHY3GADWFA4KD67TFYUIUQNLJMNXYAS",
                ConcurrencyStamp = "5d4fdb87-23b1-4da2-9e3e-a8b4df7a283f",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            user.PasswordHash = hasher.HashPassword(user, "guest123");
            users.Add(user);

            return users;
        }
    }
}
