namespace Interview.API.Model;

public struct InterviewDto
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public string PanelistName { get; set; }
    public DateTime ScheduledOn { get; set; }
    public string Status { get; set; }
    public bool FeedbackSubmitted { get; set; }
}