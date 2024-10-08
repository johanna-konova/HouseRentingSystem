using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace HouseRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IHouseService houseService;

        public HomeController(
            ILogger<HomeController> _logger,
            IHouseService _houseService)
        {
            logger = _logger;
            houseService = _houseService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction(nameof(Index), "Home", new { area = "Admin" });
            }

            var model = await houseService.GetLastThreeAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
