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

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users;
    }

    public async Task CreateUserAsync(User user)
    {
        await _userRepository.AddAsync(user);
    }

}
