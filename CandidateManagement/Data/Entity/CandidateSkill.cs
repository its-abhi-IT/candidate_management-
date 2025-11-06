namespace Candidate.API.Data.Entity;

public class CandidateSkill
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public string SkillName { get; set; } = default!;
    public int ExperienceYears { get; set; }
}