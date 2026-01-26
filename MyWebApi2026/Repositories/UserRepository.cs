using MyWebApi2026.Models;
using MyWebApi2026.Repositories.Interface;

namespace MyWebApi2026.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "John" },
        new User { Id = 2, Name = "Raj" }
    };

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

}
