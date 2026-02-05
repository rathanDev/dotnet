namespace SchedulerService.Services;

public class JobService : IJobService
{
    private readonly ILogger<JobService> _log;
    private readonly HttpClient _httpClient;

    public JobService(HttpClient httpClient, ILogger<JobService> log)
    {
        _httpClient = httpClient;
        _log = log;
    }

    public async Task doWork()
    {
        Console.WriteLine("JobService is doing work...");
        var period = DateTime.UtcNow.AddMonths(-1).ToString("yyyy-MM");
        _log.LogInformation("Monthly trigger job started for period {Period}", period);
        try
        {
            var response = await _httpClient.PostAsync($"https://example.com/api/trigger-monthly-process?period={period}", null);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Error occurred while executing monthly trigger job for period {Period}", period);
        }
        //await Task.Delay(1000);
    }

}
