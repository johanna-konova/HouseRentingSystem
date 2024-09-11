using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static HouseRentingSystem.Core.Constants.ModelsConstants;

namespace HouseRentingSystem.Web.Controllers
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
            var userId = User.Id();
            var agentId = await agentService.GetAgentIdAsync(userId);

            var userHouses = agentId != null
                ? await houseService.GetManagedByAgentIdAsync(agentId.Value)
                : await houseService.GetRentedByUserIdAsync(userId);

            return View(userHouses);
        }

        [AllowAnonymous]
        [ExistingHouse]
        public async Task<IActionResult> Details(string id)
        {
            var house = await houseService.GetDetailsAsync(Guid.Parse(id));

            return View(house);
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

        [Agent]
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
            var newHouseId = await houseService.CreateAsync(model, agentId.Value);

            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }

        [ExistingHouse]
        [Creator]
        public async Task<IActionResult> Edit(string id)
        {
            var houseToEdit = await houseService.GetDetailsAsync(Guid.Parse(id));

            var model = new HouseFormModel()
            {
                Title = houseToEdit!.Title,
                Address = houseToEdit.Address,
                Description = houseToEdit.Description,
                ImageUrl = houseToEdit.ImageUrl,
                PricePerMonth = houseToEdit.PricePerMonth,
                CategoryId = await houseService.GetHouseCategoryIdAsync(houseToEdit.Id),
                Categories = await categoryService.GetAllAsync(),
            };

            return View(model);
        }

        [ExistingHouse]
        [Creator]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, HouseFormModel model)
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

            await houseService.EditAsync(Guid.Parse(id), model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [ExistingHouse]
        [Creator]
        public async Task<IActionResult> Delete(string id)
        {
            var houseToDelete = await houseService.GetDetailsForDeleteFormAsync(Guid.Parse(id));

            return View(houseToDelete);
        }

        [ExistingHouse]
        [Creator]
        [HttpPost]
        public async Task<IActionResult> Delete(HouseDeleteViewModel model)
        {
            await houseService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [NotAgent]
        [ExistingHouse]
        [NotReneted]
        [HttpPost]
        public async Task<IActionResult> Rent(string id)
        {
            await houseService.RentAsync(Guid.Parse(id), User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [ExistingHouse]
        [Rented]
        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            await houseService.LeaveAsync(Guid.Parse(id));

            return RedirectToAction(nameof(Mine));
        }
    }
}
