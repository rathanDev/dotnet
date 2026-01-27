using Microsoft.AspNetCore.Mvc;
using MyWebApi2026.Services.Interfaces;
using MyWebApi2026.DTOs;

namespace MyWebApi2026.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        if (req.Username != "admin" || req.Password != "password")
        {
            return Unauthorized();
        }

        var tokenStr = _tokenService.GenerateToken(req);

        return Ok(new
        {
            token = tokenStr
        });
    }

}
