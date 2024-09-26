using HouseRentingSystem.Core.Contracts;
using System.Text.RegularExpressions;

namespace HouseRentingSystem.Core.Extensions
{
    public static class ModelsExtensions
    {
        public static string GetInformation(this IHouseModel house)
        {
            string information =
                $"{house.Title.Replace(" ", "-")} - {GetAddress(house.Address)}";

            return Regex.Replace(information, @"[^a-zA-Z0-9\-]", string.Empty);
        }

        private static string GetAddress(string address)
            => string.Join("-", address.Split(' ').Take(3));
    }
}
