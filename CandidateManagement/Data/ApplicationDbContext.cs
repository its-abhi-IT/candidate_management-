using Microsoft.EntityFrameworkCore;
using Candidate.API.Data.Entity;

namespace Candidate.API.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Candidates> Candidates { get; set; }
    public DbSet<CandidateSkill> CandidateSkills { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
}

