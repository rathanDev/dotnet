using Microsoft.AspNetCore.Mvc;

namespace SchedulerService.Controllers;

public class HealthController : ControllerBase
{

    [HttpPost("api/health")]
    public IActionResult HealthCheck()
    {
        return Ok("Service is healthy");
    }

}
