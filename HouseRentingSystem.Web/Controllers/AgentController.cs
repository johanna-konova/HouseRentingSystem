using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
	public class AgentController : Controller
	{
		private readonly IAgentService agentService;
		private readonly IHouseService houseService;

        public AgentController(
			IAgentService _agentService,
			IHouseService _houseService)
        {
			agentService = _agentService;
			houseService = _houseService;
        }

        public IActionResult Index() => RedirectToAction(nameof(Become));

		public async Task<IActionResult> Become()
        {
            if (await agentService.IsAgentAsync(User.Id()))
            {
                TempData[ErrorMessage] = AlreadyAgent;

                return RedirectToAction(nameof(HouseController.Mine), "House");
            }

            return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            if (await agentService.IsAgentAsync(User.Id()))
            {
                TempData[ErrorMessage] = AlreadyAgent;

                return RedirectToAction(nameof(HouseController.Mine), "House");
            }

            if (await agentService.hasAgentWithGivenPhoneNumberAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (await houseService.hasRentAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasRents);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await agentService.CreateAsync(User.Id(), model);

            return RedirectToAction(nameof(HouseController.All), "Houses");
		}
	}
}
