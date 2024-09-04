using HouseRentingSystem.Controllers;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Web.Attributes
{
    public class CreatorAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IHouseService? houseService =
                context.HttpContext.RequestServices.GetService<IHouseService>();

            if (houseService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            var houseId = Guid.Parse((string)context.ActionArguments["id"]!);
            var userId = context.HttpContext.User.Id();

            if (await houseService!.IsAgentHouseCreatorAsync(houseId, userId) == false)
            {
                var controller = (Controller)context.Controller;
                controller.TempData[ErrorMessage] = MustBeHouseCreator;

                context.Result = new RedirectToActionResult(nameof(HouseController.Mine), "House", null);
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
