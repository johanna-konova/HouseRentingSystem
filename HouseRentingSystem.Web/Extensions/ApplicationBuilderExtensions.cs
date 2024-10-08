using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using static HouseRentingSystem.Infrastructure.Constants.SeedDataConstants;
using static HouseRentingSystem.Web.Common.CommonHelpers;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> SeedUsersClaim(this IApplicationBuilder app)
        {
            using var scopedServices =
                app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var agentUser = await userManager.FindByEmailAsync(AgentUserEmail);
            await AddUserClaimAsync(userManager, agentUser, null);

            var guestUser = await userManager.FindByEmailAsync(GuestUserEmail);
            await AddUserClaimAsync(userManager, guestUser, null);

            return app;
        }

        public static async Task<IApplicationBuilder> SeedAdmin(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            if (await roleManager.RoleExistsAsync(AdminUserRoleName) == false)
            {
                var role = new IdentityRole<Guid>()
                {
                    Name = AdminUserRoleName,
                    NormalizedName = AdminUserRoleName.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                };

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(AdminUserEmail);

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name!);
                }
            }

            return app;
        }
    }
}
