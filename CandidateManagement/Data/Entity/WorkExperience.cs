namespace Candidate.API.Data.Entity;

public class WorkExperience
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public string CompanyName { get; set; } = default!;
    public string Role { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
