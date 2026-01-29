using UserService.Models;

namespace UserService.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);

    Task<IEnumerable<User>> GetAllAsync();

    Task<User?> GetByUsernameAsync(string username);
}
