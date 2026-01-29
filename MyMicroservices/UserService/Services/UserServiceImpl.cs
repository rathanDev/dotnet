using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.DTOs;
using UserService.Mappers;
using UserService.Models;
using UserService.Repositories.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Services;

public class UserServiceImpl : IUserService
{
    //private readonly AppDbContext _dbContext;
    private readonly IUserRepository _userRepository;

    public UserServiceImpl(IUserRepository userRepository)                // AppDbContext dbContext
    {
        //_dbContext = dbContext;
        _userRepository = userRepository;
    }   

    public async Task<UserDto> CreateUserAsync(CreateUserRequest req)
    {
        var user = new User { 
            Username = req.Username, 
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password) ,
            Role = req.Role
        };
        //_dbContext.Users.Add(user);
        //await _dbContext.SaveChangesAsync();
        await _userRepository.AddAsync(user);
        return UserMapper.ToDto(user);
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username)
    {
        //var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        var user = new User
        {
            Username = "DummyUser",
            PasswordHash = "hashed_password",
            Role = "User"
        };
        if (user == null) return null;
        return UserMapper.ToDto(user);
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        //var users = await _dbContext.Users.ToListAsync();
        var users = await _userRepository.GetAllAsync();
        var dtos = users.Select(UserMapper.ToDto).ToList();
        return dtos;
    }

}
