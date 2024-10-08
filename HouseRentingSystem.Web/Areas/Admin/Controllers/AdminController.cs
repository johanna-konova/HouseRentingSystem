using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HouseRentingSystem.Infrastructure.Constants.SeedDataConstants;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminUserRoleName)]
    public class AdminController : Controller
    {
    }
}
