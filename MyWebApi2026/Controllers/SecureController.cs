using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi2026.Controllers;

[ApiController]
[Route("api/secure")]
public class SecureController : ControllerBase
{

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(new {message = "You are authenticated", User = User.Identity?.Name });
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdmin()
    {
        return Ok(new { message = "You are an admin", User = User.Identity?.Name });
    }

}
