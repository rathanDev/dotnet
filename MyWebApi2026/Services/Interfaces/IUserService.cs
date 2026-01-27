using MyWebApi2026.Models;

namespace MyWebApi2026.Services.Interfaces;

public interface IUserService
{

    Task<IEnumerable<User>> GetAllUsersAsync();
    
    Task<User?> GetUserByIdAsync(int id);

    Task CreateUserAsync(User user);

}
