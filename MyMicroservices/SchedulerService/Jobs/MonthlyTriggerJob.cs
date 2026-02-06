using SchedulerService.Services;

namespace SchedulerService.Jobs;

public class MonthlyTriggerJob
{
    private readonly ILogger<MonthlyTriggerJob> _log;
    private readonly IJobService _jobService;

    public MonthlyTriggerJob(ILogger<MonthlyTriggerJob> log, IJobService jobService)
    {
        _log = log;
        _jobService = jobService;
    }

    public async Task TriggerAsync()
    {
        _log.LogInformation("MonthlyTriggerJob started at: {time}", DateTimeOffset.Now);
        try
        {
            await _jobService.doWork();
            _log.LogInformation("MonthlyTriggerJob completed at: {time}", DateTimeOffset.Now);
        } catch(Exception ex)
        {
            _log.LogError(ex, "Error occurred while executing MonthlyTriggerJob at: {time}", DateTimeOffset.Now);
            throw; // rethrow to let Hangfire know the job failed
        }

    }

}
