using MyWebApi2026.Models;

namespace MyWebApi2026.Services.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);
}
