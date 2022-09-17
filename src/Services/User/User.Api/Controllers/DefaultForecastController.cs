using Microsoft.AspNetCore.Mvc;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultForecastController : ControllerBase
    {
        private readonly ILogger<DefaultForecastController> _logger;

        public DefaultForecastController(ILogger<DefaultForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Runing...");
        }
    }
}