using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HouseRentingSystem.Web.Common
{
    public static class CommonHelpers
    {
        public static async Task AddUserClaimAsync(
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

        public static async Task<List<T>> GetCachedDataAsync<T>(
            IDistributedCache cache,
            string cacheKey,
            Func<Task<IEnumerable<T>>> getDataFunc) // Приема IEnumerable<T> вместо List<T>
        {
            var cachedDataAsString = await cache.GetStringAsync(cacheKey);

            if (cachedDataAsString != null)
            {
                return JsonConvert.DeserializeObject<List<T>>(cachedDataAsString)!;
            }

            var data = (await getDataFunc()).ToList();

            var cacheOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            await cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(data), cacheOptions);

            return data;
        }
    }
}
