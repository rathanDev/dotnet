using Microsoft.EntityFrameworkCore;
using MyWebApi2026.Data;
using MyWebApi2026.Models;
using MyWebApi2026.Repositories.Interface;

namespace MyWebApi2026.Repositories;

public class UserRepository : IUserRepository
{
    //private readonly List<User> _users = new()
    //{
    //    new User { Id = 1, Name = "John" },
    //    new User { Id = 2, Name = "Raj" }
    //};

    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        return users;
    }

    public Task<User?> GetByIdAsync(int id)
    {
        var user = _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return user;
        //return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        //return user;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

}
