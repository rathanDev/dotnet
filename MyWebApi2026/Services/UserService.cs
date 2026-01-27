using MyWebApi2026.DTOs.Users;
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

    public async Task<UserResponse?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return null;
        }
        var res = new UserResponse
        {
            Id = user.Id,
            Name = user.Name
        };
        return res;
    }

    public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var res = users.Select(u => new UserResponse
        {
            Id = u.Id,
            Name = u.Name
        }).ToList();
        return res;
    }

    public async Task<UserResponse> CreateUserAsync(CreateUserRequest req)
    {
        var user = new User
        {
            Name = req.Name
        };
        await _userRepository.AddAsync(user);
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name
        };
    }

}
