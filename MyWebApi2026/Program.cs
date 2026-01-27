using Microsoft.EntityFrameworkCore;
using MyWebApi2026.Data;
using MyWebApi2026.Repositories;
using MyWebApi2026.Repositories.Interface;
using MyWebApi2026.Services;
using MyWebApi2026.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MyInmemoryDb"));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
