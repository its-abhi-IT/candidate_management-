namespace Interview.API.Data.Entity;

public class InterviewEntity
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public string PanelistName { get; set; } = default!;
    public DateTime ScheduledOn { get; set; }
    public string Status { get; set; } = default!;
    public bool FeedbackSubmitted { get; set; }
}
