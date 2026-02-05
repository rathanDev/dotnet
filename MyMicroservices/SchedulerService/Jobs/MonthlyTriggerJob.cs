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
        await _jobService.doWork();
        _log.LogInformation("MonthlyTriggerJob completed at: {time}", DateTimeOffset.Now);
    }

}
