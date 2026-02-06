using Hangfire;
using Hangfire.SqlServer;
using SchedulerService.Scheduler;
using SchedulerService.Schedulers;
using SchedulerService.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddHttpClient();

builder.Services.AddControllers();

builder.Services.AddHangfire(config =>
{
    config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()

        .UseSqlServerStorage(
            builder.Configuration.GetConnectionString("Hangfire"),
            new SqlServerStorageOptions {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }
        );
});

builder.Services.AddHangfireServer(options =>
{
    options.WorkerCount = Environment.ProcessorCount * builder.Configuration.GetValue<int>("Hangfire:WorkerMultiplier");
    options.Queues = new[] 
    {
        builder.Configuration.GetValue<string>("Hangfire:Queue")
    };
});

builder.Services.AddSingleton<IRecurringJobRegistrar, RecurringJobRegistrar>();

builder.Services.AddScoped<IJobService, JobService>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire"); 

app.MapControllers();

var registrar = app.Services.GetRequiredService<IRecurringJobRegistrar>();
registrar.Register();

app.Run();



// Server=localhost,1433;Database=UserDb;User Id=sa;Password=YourStrong@Password1;TrustServerCertificate=True

//// Add services to the container.
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

//app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
