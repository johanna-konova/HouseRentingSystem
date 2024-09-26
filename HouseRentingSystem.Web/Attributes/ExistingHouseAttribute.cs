using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

using static HouseRentingSystem.Web.Attributes.Common.CommonFunctionalities;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Core.Constants.MessageTypes;
using HouseRentingSystem.Web.Controllers;
using HouseRentingSystem.Core.Extensions;

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

                var house = await houseService.GetDetailsAsync(houseId);
                var informationValue = (string?)context.RouteData.Values["information"];

                if (house != null && (informationValue == null || informationValue == house!.GetInformation()))
                {
                    await next();
                    return;
                }
            }

            HandleError(context, ErrorMessage, NonExistentPage, nameof(HouseController.All), "House");
        }
    }
}
