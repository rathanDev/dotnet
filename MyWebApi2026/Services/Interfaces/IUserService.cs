using MyWebApi2026.DTOs.Users;
using MyWebApi2026.Models;

namespace MyWebApi2026.Services.Interfaces;

public interface IUserService
{

    Task<IEnumerable<UserResponse>> GetAllUsersAsync();
    // Task<IReadOnlyList<User>>
    
    Task<UserResponse?> GetUserByIdAsync(int id);

    Task<UserResponse> CreateUserAsync(CreateUserRequest req);

}
