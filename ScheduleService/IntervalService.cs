using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cronos;

public class IntervalService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<IntervalService> _logger;
    private readonly CronExpression _cronExpression;
    private readonly TimeZoneInfo _timeZone;

    public IntervalService(IServiceScopeFactory scopeFactory, ILogger<IntervalService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        
        // Example CRON: At 12:00 PM every day
        _cronExpression = CronExpression.Parse("0 0 12 * * *");
        _timeZone = TimeZoneInfo.Local; // or TimeZoneInfo.Utc
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var utcNow = DateTime.UtcNow;
            var nextOccurrence = _cronExpression.GetNextOccurrence(utcNow, _timeZone);

            if (nextOccurrence.HasValue)
            {
                var delay = nextOccurrence.Value - utcNow;
                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, stoppingToken);
                }

                // Execute the EF Core operation
                await ProcessDatabaseTaskAsync();

                // Small delay to prevent immediate re-triggering at the same millisecond
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            else
            {
                break; // No more occurrences
            }
        }
    }

    private async Task ProcessDatabaseTaskAsync()
    {
        // 1. Create a DI scope to instantiate your scoped DbContext safely
        using var scope = _scopeFactory.CreateScope();
        //var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try
        {
            _logger.LogInformation("Executing database task via CRON...");

            // 2. Perform your Entity Framework operations
            // e.g., var pendingRecords = await dbContext.Records.Where(...).ToListAsync();
            // await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the scheduled EF Core task.");
        }
    }
}
