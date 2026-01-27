using Microsoft.EntityFrameworkCore;
using MyWebApi2026.Models;

namespace MyWebApi2026.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

}
