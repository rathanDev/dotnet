using MyWebApi2026.Models;

namespace MyWebApi2026.Repositories.Interface;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
}
