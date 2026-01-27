using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Services.Interfaces;

namespace UserService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req)
    {
        if (req.Username != "admin" || req.Password != "password")
        {
            return Unauthorized();
        }
        var tokenStr = _authService.GenerateToken(req);

        return Ok(new {token = tokenStr});
    }

}
