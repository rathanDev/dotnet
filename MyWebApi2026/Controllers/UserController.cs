using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

}
