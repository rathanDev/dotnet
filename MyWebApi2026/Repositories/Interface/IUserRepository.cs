using MyWebApi2026.Models;

namespace MyWebApi2026.Repositories.Interface;

public interface IUserRepository
{

    Task<IEnumerable<User>> GetAllAsync();
    // Task<IReadOnlyList<User>> GetAll();

    Task<User?> GetByIdAsync(int id);

    Task AddAsync(User user);

}
