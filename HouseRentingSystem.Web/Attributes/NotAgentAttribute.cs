using HouseRentingSystem.Controllers;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Web.Attributes
{
	public class NotAgentAttribute : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			IAgentService? agentService =
				context.HttpContext.RequestServices.GetService<IAgentService>();

			if (agentService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
				return;
			}

            if (await agentService!.IsAgentAsync(context.HttpContext.User.Id()))
			{
				var controller = (Controller)context.Controller;
				controller.TempData[ErrorMessage] = AlreadyAgent;

				context.Result = new RedirectToActionResult(nameof(HouseController.Mine), "House", null);
				return;
			}

            await next();
		}
	}
}
