using CoreServer.DataStorage;
using CoreServer.Hubs;
using CoreServer.TimerFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoreServer.Controllers
{
    [Route("api/charts")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;

        public ChartsController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("clientPolicyCallbackChartData", DataManager.GetData()));

            return Ok(new { Message = "Request completed" });
        }
    }
}
