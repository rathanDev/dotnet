using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Services.Interfaces;

namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }

    [HttpGet("by-username/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userService.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest req)
    {
        var user = await _userService.CreateUserAsync(req);
        return Ok(user);
    }

}
