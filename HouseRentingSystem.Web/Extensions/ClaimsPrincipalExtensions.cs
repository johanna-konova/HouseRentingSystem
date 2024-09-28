using static HouseRentingSystem.Infrastructure.Constants.SeedDataConstants;

namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            var idAsString = user.FindFirstValue(ClaimTypes.NameIdentifier);

            return idAsString == null ? Guid.Empty : Guid.Parse(idAsString);
        }

        public static string? FullName(this ClaimsPrincipal user)
            => user.FindFirstValue("customClaims/fullname");

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdminUserRoleName);
    }
}
