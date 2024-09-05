using HouseRentingSystem.Controllers;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

using static HouseRentingSystem.Web.Attributes.Common.CommonFunctionalities;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Core.Constants.MessageTypes;

namespace HouseRentingSystem.Web.Attributes
{
    public class ExistingHouseAttribute : ActionFilterAttribute
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
                    return;
                }

                if (await houseService!.HasHouseWithGivenIdAsync(houseId))
                {
                    await next();
                    return;
                }
            }

            HandleError(context, ErrorMessage, NonExistentPage, nameof(HouseController.All), "House");
        }
    }
}
