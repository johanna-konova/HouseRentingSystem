using HouseRentingSystem.Controllers;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Web.Attributes
{
	public class Agent : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			IAgentService? agentService =
				context.HttpContext.RequestServices.GetService<IAgentService>();

			if (agentService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

            if (await agentService!.IsAgentAsync(context.HttpContext.User.Id()) == false)
			{
				var controller = (Controller)context.Controller;
				controller.TempData[ErrorMessage] = MustBeAgent;

				context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
			}

            await base.OnActionExecutionAsync(context, next);
		}
	}
}
