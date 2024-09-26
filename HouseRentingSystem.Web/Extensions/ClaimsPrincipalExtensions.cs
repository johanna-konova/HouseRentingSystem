namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            var idAsString = user.FindFirstValue(ClaimTypes.NameIdentifier);

            return idAsString == null ? Guid.Empty : Guid.Parse(idAsString);
        }
    }
}
