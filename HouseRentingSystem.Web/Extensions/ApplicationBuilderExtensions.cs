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
            await AddUserClaim(userManager, agentUser, null);

            var guestUser = await userManager.FindByEmailAsync(GuestUserEmail);
            await AddUserClaim(userManager, guestUser, null);

            return app;
        }

        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            Task
                .Run(async() =>
                {
                    if (await roleManager.RoleExistsAsync("Administrator"))
                    {
                        return;
                    }

                    var role = new IdentityRole<Guid>("Administrator");

                    await roleManager.CreateAsync(role);

                    var admin = await userManager.FindByEmailAsync("admin@mail.com");

                    if (admin != null)
                    {
                        await userManager.AddToRoleAsync(admin, role.Name);
                    }
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
