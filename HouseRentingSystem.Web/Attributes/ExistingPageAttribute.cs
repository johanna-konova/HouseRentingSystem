using HouseRentingSystem.Controllers;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Web.Attributes
{
    public class ExistingPageAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.TryGetValue("id", out var idAsObj)
                && idAsObj is string id
                && Guid.TryParse(id, out Guid houseId))
            {
                IHouseService? houseService =
                    context.HttpContext.RequestServices.GetService<IHouseService>();

                if (houseService == null)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    return;
                }

                if (await houseService!.HasHouseWithGivenId(houseId))
                {
                    await next();
                    return;
                }
            }

            var controller = (Controller)context.Controller;
            controller.TempData[ErrorMessage] = NonExistentPage;

            context.Result = new RedirectToActionResult(nameof(HouseController.All), "House", null);
        }
    }
}
