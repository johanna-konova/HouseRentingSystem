using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

using static HouseRentingSystem.Web.Common.CommonHelpers;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;
        private readonly IDistributedCache cache;

        public UserController(
            IUserService _userService,
            IDistributedCache _cache)
        {
            userService = _userService;
            cache = _cache;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            //var users = await userService.GetAllAsync();

            var users = await GetCachedDataAsync(
                cache,
                "UsersCacheKey",
                userService.GetAllAsync);

            return View(users);
        }
    }
}
