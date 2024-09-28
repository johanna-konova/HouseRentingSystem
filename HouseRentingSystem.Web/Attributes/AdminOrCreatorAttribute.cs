using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static HouseRentingSystem.Web.Attributes.Common.CommonFunctionalities;
using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using HouseRentingSystem.Web.Controllers;

namespace HouseRentingSystem.Web.Attributes
{
    public class AdminOrCreatorAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Guid houseId = ParseId(context);

            if (houseId != Guid.Empty)
            {
                IHouseService? houseService =
                context.HttpContext.RequestServices.GetService<IHouseService>();

                if (houseService == null)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }

                var userId = context.HttpContext.User.Id();

                if (await houseService!.IsAgentHouseCreatorAsync(houseId, userId)
                    || context.HttpContext.User.IsAdmin())
                {
                    await next();
                    return;
                }
            }

            HandleError(context, ErrorMessage, MustBeAdminOrHouseCreator, nameof(HouseController.Mine), "House");
        }
    }
}
