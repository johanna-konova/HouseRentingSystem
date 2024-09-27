using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HouseRentingSystem.Web.Common
{
    public static class CommonHelpers
    {
        public static async Task AddUserClaim(
            UserManager<ApplicationUser> userManager,
            ApplicationUser? user,
            SignInManager<ApplicationUser>? signInManager)
        {
            if (user != null)
            {
                var userClaims = await userManager.GetClaimsAsync(user);

                string fullNameClaimType = "customClaims/fullname";

                var fullNameClaim = userClaims.FirstOrDefault(c => c.Type == fullNameClaimType);

                if (fullNameClaim == null)
                {
                    string fullNameClaimValue = $"{user.FirstName} {user.LastName}";
                    await userManager.AddClaimAsync(user, new Claim(fullNameClaimType, fullNameClaimValue));

                    if (signInManager != null)
                    {
                        await signInManager.RefreshSignInAsync(user);
                    }
                }
            }
        }
    }
}
