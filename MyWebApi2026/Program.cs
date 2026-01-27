using Microsoft.EntityFrameworkCore;
using MyWebApi2026.Data;
using MyWebApi2026.Middleware;
using MyWebApi2026.Repositories;
using MyWebApi2026.Repositories.Interface;
using MyWebApi2026.Services;
using MyWebApi2026.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MyInmemoryDb"));

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<CustomExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
