using CandidateCleanup.Job.Data.Entity;

namespace CandidateCleanup.Job.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CandidatesEntity> Candidates { get; set; }
}
