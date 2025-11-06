namespace Candidate.API.Models;

public struct CandidateSkillDto
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public string SkillName { get; set; }
    public int ExperienceYears { get; set; }
}
