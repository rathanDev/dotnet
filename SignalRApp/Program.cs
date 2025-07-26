using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SignalRApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true);
    });
});


builder.Services.AddSignalR();

var app = builder.Build();

// app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");

app.MapHub<ChatHub>("/chathub");

app.Run();