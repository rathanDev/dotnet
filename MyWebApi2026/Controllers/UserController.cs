using Microsoft.AspNetCore.Mvc;
using MyWebApi2026.DTOs.Users;
using MyWebApi2026.Services.Interfaces;

namespace MyWebApi2026.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest req)
    {
        var userResponse = await _userService.CreateUserAsync(req);
        return CreatedAtAction(nameof(GetUserById), new {id = userResponse.Id}, userResponse);
    }

}
