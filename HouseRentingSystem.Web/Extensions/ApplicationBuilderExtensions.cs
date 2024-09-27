﻿using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static HouseRentingSystem.Infrastructure.Constants.SeedDataConstants;

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
            await AddUserClaim(
                userManager,
                agentUser,
                AgentUserFirstName,
                AgentUserLastName);

            var guestUser = await userManager.FindByEmailAsync(GuestUserEmail);
            await AddUserClaim(
                userManager,
                guestUser,
                GuestFirstName,
                GuestLastName);

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

        private static async Task AddUserClaim(
            UserManager<ApplicationUser> userManager,
            ApplicationUser? user,
            string userFirstName,
            string userLastName)
        {
            if (user != null)
            {
                var userClaims = await userManager.GetClaimsAsync(user);

                var fullNameClaim = userClaims.FirstOrDefault(c => c.Type == "customClaims/fullname");

                if (fullNameClaim == null)
                {
                    await userManager.AddClaimAsync(user, new Claim("customClaims/fullname", $"{userFirstName} {userLastName}"));
                }
            }
        }
    }
}
