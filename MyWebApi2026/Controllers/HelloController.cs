using Microsoft.AspNetCore.Mvc;

namespace MyWebApi2026.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Greet()
    {
        return Ok("Hi!");
    }

    [HttpGet("{name}")]
    public IActionResult GreetWithName(string name)
    {
        return Ok($"Hi {name}!");
    }

}
