using System.ComponentModel.DataAnnotations;

namespace Candidate.API.Models;

public struct CandidateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    [Range(5, int.MaxValue)]
    public int ExperienceYears { get; set; }
    public bool IsActive { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }
}