namespace Candidate.API.Models;

public struct WorkExperienceDto
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public string CompanyName { get; set; }
    public string Role { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
