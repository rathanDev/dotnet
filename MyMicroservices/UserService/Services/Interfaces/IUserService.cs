using UserService.DTOs;
using UserService.Models;

namespace UserService.Services.Interfaces;

public interface IUserService
{

    Task<List<UserDto>> GetUsersAsync();

    Task<UserDto?> GetUserByUsernameAsync(string username);

    Task<UserDto> CreateUserAsync(CreateUserRequest req);

}
