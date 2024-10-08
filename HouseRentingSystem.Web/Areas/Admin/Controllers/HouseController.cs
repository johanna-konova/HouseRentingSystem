using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;

using static HouseRentingSystem.Web.Common.CommonHelpers;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class HouseController : AdminController
    {
        private readonly IAgentService agentService;
        private readonly IHouseService houseService;
        private readonly IDistributedCache cache;

        public HouseController(
            IAgentService _agentService,
            IHouseService _houseService,
            IDistributedCache _cache)
        {
            agentService = _agentService;
            houseService = _houseService;
            cache = _cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Mine()
        {
            var adminUserId = User.Id();
            var adminAgentId = await agentService.GetAgentIdAsync(adminUserId);

            var adminHouses = await houseService.GetAdminHousesAsync((Guid)adminAgentId, adminUserId);

            return View(adminHouses);
        }

        [Route("Rent/All")]
        public async Task<IActionResult> Rented()
        {
            var rentedHouses = await houseService.GetAllRentedAsync();

            /*var rentedHouses = await GetCachedDataAsync(
                cache,
                "RentsCacheKey",
                houseService.GetAllRentedAsync);*/

            return View(rentedHouses);
        }
    }
}
