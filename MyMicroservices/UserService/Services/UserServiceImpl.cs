using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.DTOs;
using UserService.Mappers;
using UserService.Models;
using UserService.Services.Interfaces;

namespace UserService.Services;

public class UserServiceImpl : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserServiceImpl(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }   

    public async Task<UserDto> CreateUserAsync(CreateUserRequest req)
    {
        var user = new User { 
            Username = req.Username, 
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password) ,
            Role = req.Role
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return UserMapper.ToDto(user);
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null) return null;
        return UserMapper.ToDto(user);
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        var users = await _dbContext.Users.ToListAsync();
        var dtos = users.Select(UserMapper.ToDto).ToList();
        return dtos;
    }

}
