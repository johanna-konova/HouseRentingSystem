using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
		private readonly IAgentService agentService;
		private readonly ICategoryService categoryService;
		private readonly IHouseService houseService;

		public HouseController(
			IAgentService _agentService,
			ICategoryService _categoryService,
			IHouseService _houseService)
		{
			agentService = _agentService;
			categoryService = _categoryService;
			houseService = _houseService;
		}

		[AllowAnonymous]
        public IActionResult Index() => RedirectToAction(nameof(All));

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllHousesQueryModel model)
        {
			var houses = await houseService.GetAllAsync(model);

			return View(houses);
        }

		public async Task<IActionResult> Mine()
		{
			return View(new AllHousesQueryModel());
		}

		public async Task<IActionResult> Details(int id)
		{
			return View(new HouseDetailsViewModel());
		}

		[Agent]
		public async Task<IActionResult> Add()
		{
			var model = new HouseFormModel()
			{
				Categories = await categoryService.GetAllAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseFormModel model)
		{
            if (await categoryService.HasCategoryWithGivenId(model.CategoryId) == false)
            {
				ModelState.AddModelError(nameof(model.CategoryId), NonExistentCategory);
			}

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllAsync();
				return View(model);
            }

			var agentId = await agentService.GetAgentIdAsync(User.Id());
			var newHouseId = await houseService.CreateAsync(model, agentId);

			return RedirectToAction(nameof(Details), new { id = newHouseId });
		}

		public async Task<IActionResult> Edit(int id)
		{
			return View(new HouseFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, HouseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}

		public async Task<IActionResult> Delete(int id)
		{
			return View(new HouseFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Delete(HouseFormModel model)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Rent(int id)
		{
			return RedirectToAction(nameof(Mine));
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			return RedirectToAction(nameof(Mine));
		}
	}
}
