using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

using static HouseRentingSystem.Web.Attributes.Common.CommonFunctionalities;
using static HouseRentingSystem.Core.Constants.MessageTypes;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using Microsoft.AspNetCore.Mvc.Controllers;
using HouseRentingSystem.Web.Controllers;

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
				string message;
				string controllerName;

                if (((ControllerActionDescriptor)context.ActionDescriptor).ActionName == "Become")
                {
					message = AlreadyAgent;
					controllerName = nameof(HouseController.Mine);
                }
				else
				{
					message = AgentIsNotAllowedToRent;
					controllerName = nameof(HouseController.All);
				}

				HandleError(context, ErrorMessage, message, controllerName, "House");
				return;
			}

            await next();
		}
	}
}
