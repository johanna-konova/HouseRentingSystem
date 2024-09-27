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
