using Microsoft.AspNetCore.Mvc;

namespace MyWebApi2026.Controllers;

[ApiController]
[Route("api/test")]
public class TestErrorController : ControllerBase
{

    [HttpGet("error")]
    public IActionResult error()
    {
        throw new InvalidOperationException("sample InvalidOperationEx!");
    }

    [HttpGet("bad")]
    public IActionResult badReq()
    {
        throw new ArgumentException("sample ArgumentEx!");
    }

}
