using MyWebApi2026.Models;
using MyWebApi2026.Repositories.Interface;
using MyWebApi2026.Services.Interfaces;

namespace MyWebApi2026.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

}
