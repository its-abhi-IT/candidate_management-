using Interview.API.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Interview.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<InterviewEntity> Interviews { get; set; }
    public DbSet<FeedbackEntity> Feedbacks { get; set; }
}
