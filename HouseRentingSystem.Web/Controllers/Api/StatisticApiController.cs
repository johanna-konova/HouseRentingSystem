using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/statistic")]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticApiController(IStatisticsService _statisticsService)
        {
            statisticsService = _statisticsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(HousesStatisticModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetHousesStatistic()
        {
            var housesStatistic = await statisticsService.GetHousesStatisticAsync();

            return Ok(housesStatistic);
        }
    }
}
