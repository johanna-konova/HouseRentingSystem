using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Web.Attributes.Common.CommonFunctionalities;

namespace HouseRentingSystem.Web.Attributes
{
    public class RentedAttribute : ActionFilterAttribute
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

                Guid userId = context.HttpContext.User.Id();

                if (await houseService!.IsRentedByUserWithGivenId(houseId, userId))
                {
                    await next();
                    return;
                }
            }

            HandleError(context, ErrorMessage, OnlyPropertyRenterIsAllowedToLeaveIt, nameof(HouseController.All), "House");
        }
    }
}
