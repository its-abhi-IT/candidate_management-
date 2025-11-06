namespace CandidateCleanup.Job.Data.Entity;

public class CandidatesEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public int ExperienceYears { get; set; }
    public bool IsActive { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }
}