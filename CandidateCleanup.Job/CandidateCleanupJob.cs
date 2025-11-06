namespace CandidateCleanup.Job;
public class CandidateCleanupJob : BackgroundService
{
    private readonly ILogger<CandidateCleanupJob> _logger;
    private readonly IServiceProvider _services;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(45);

    public CandidateCleanupJob(ILogger<CandidateCleanupJob> logger, IServiceProvider services)
    {
        _logger = logger;
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("CandidateCleanupJob started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var cutoffDate = DateTime.UtcNow.AddDays(-90);

                var staleCandidates = await dbContext.Candidates
                    .Where(c => c.IsActive &&
                                (c.CreatedOn < cutoffDate)).ToArrayAsync(stoppingToken).ConfigureAwait(false);

                foreach (var candidate in staleCandidates)
                {
                    candidate.IsActive = false;
                    candidate.LastUpdatedOn = DateTime.Now;
                    _logger.LogInformation($"Archived candidate ID: {candidate.Id}");
                }

                await dbContext.SaveChangesAsync(stoppingToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during candidate cleanup.");
            }

            await Task.Delay(_interval, stoppingToken).ConfigureAwait(false);
        }

        _logger.LogInformation("CandidateCleanupJob stopped.");
    }
}
