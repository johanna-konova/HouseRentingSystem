using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"),
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com".ToUpper(),
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com".ToUpper(),
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
                Id = Guid.Parse("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"),
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com".ToUpper(),
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com".ToUpper(),
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
