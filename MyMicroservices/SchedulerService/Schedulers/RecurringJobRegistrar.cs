using Hangfire;
using SchedulerService.Jobs;
using SchedulerService.Schedulers;

namespace SchedulerService.Scheduler;

public class RecurringJobRegistrar : IRecurringJobRegistrar
{
    private readonly IServiceProvider _serviceProvider;

    public RecurringJobRegistrar(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Register()
    {
        RegisterJob();
    }

    public void RegisterJob()
    {
        // Key point: Hangfire ensures the job with same ID is only registered once
        RecurringJob.AddOrUpdate<MonthlyTriggerJob>(
            recurringJobId: "monthly-trigger-job",
            methodCall: job => job.TriggerAsync(),
            cronExpression: "0 10 * * *",
            options: new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Utc,
                QueueName = "scheduler"
            });
    }

}
