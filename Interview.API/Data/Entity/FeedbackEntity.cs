namespace Interview.API.Data.Entity;

public class FeedbackEntity
{
    public int Id { get; set; }
    public int InterviewId { get; set; }
    public int Rating { get; set; }
    public string? Comments { get; set; }
    public DateTime SubmittedOn { get; set; }
}
