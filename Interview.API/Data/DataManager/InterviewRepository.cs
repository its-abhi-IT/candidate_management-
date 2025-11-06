using Infrastructure.Response;
using Interview.API.Contracts;
using Interview.API.Data.Entity;
using Interview.API.Model;

namespace Interview.API.Data.DataManager;

public class InterviewRepository : IInterviewRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IDbFactoryBase<InterviewEntity> intervireRepo;
    private readonly IDbFactoryBase<FeedbackEntity> feedbackRepo;

    public InterviewRepository(ApplicationDbContext context, 
        IDbFactoryBase<InterviewEntity> intervireRepo, 
        IDbFactoryBase<FeedbackEntity> feedbackRepo)
    {
        _context = context;
        this.intervireRepo = intervireRepo;
        this.feedbackRepo = feedbackRepo;
    }

    public async Task<ServiceResponse<InterviewDto>> CreateInterviewAsync(InterviewDto interview)
    {
        InterviewEntity interviewEntity = new()
        {
            Id = interview.Id,
            CandidateId = interview.CandidateId,
            PanelistName = interview.PanelistName,
            ScheduledOn = interview.ScheduledOn,
            Status = interview.Status,
            FeedbackSubmitted = interview.FeedbackSubmitted,
        };
        await intervireRepo.AddAsync(interviewEntity);
        return new ServiceResponse<InterviewDto>
        {
            Data = interview,Success = true,
        };
    }

    public async Task<ServiceResponse<InterviewDto[]>> GetAllInterviewsAsync()
    {
        var resp = await intervireRepo.GetAllAsync();

        return new ServiceResponse<InterviewDto[]>
        {
            Data = [.. resp.Select(c => new InterviewDto
        {
            Id = c.Id,
            CandidateId = c.CandidateId,
            PanelistName = c.PanelistName,
            ScheduledOn = c.ScheduledOn,
            Status = c.Status,
            FeedbackSubmitted = c.FeedbackSubmitted,
        })],
            Success = true,
        };
    }

    public async Task<ServiceResponse<InterviewDto?>> GetInterviewByIdAsync(int id)
    {
        var resp = await intervireRepo.GetByIdAsync(id);
        return new ServiceResponse<InterviewDto?>
        {
            Data = new InterviewDto
            {
                Id = resp.Id,
                CandidateId = resp.CandidateId,
                PanelistName = resp.PanelistName,
                ScheduledOn = resp.ScheduledOn,
                Status = resp.Status,
                FeedbackSubmitted = resp.FeedbackSubmitted,
            },Success = true,

        };
    }

    public async Task<ServiceResponse<InterviewDto[]>> GetInterviewsByCandidateIdAsync(int candidateId)
    {
        var resp = await intervireRepo.GetAsync(i=>i.CandidateId==candidateId);
        return new ServiceResponse<InterviewDto[]>
        {
            Data = [.. resp.Select(c => new InterviewDto
        {
            Id= c.Id,
            CandidateId = c.CandidateId,
            PanelistName = c.PanelistName,
            ScheduledOn = c.ScheduledOn,
            Status = c.Status,
            FeedbackSubmitted = c.FeedbackSubmitted,
        })], Success = true,
        };
    }

    public async Task<ServiceResponse<FeedbackDto?>> SubmitFeedbackAsync(int interviewId, FeedbackDto feedback)
    {
        var interview = await intervireRepo.GetByIdAsync(interviewId);
        if (interview == null) throw new Exception("Interview not found");

        feedback.InterviewId = interviewId;
        feedback.SubmittedOn = DateTime.UtcNow;
        FeedbackEntity entity = new()
        {
            Id = feedback.Id,
            InterviewId = feedback.InterviewId,
            Rating = feedback.Rating,
            Comments = feedback.Comments,
            SubmittedOn = DateTime.UtcNow,
        };
        await feedbackRepo.AddAsync(entity).ConfigureAwait(false);
        return new ServiceResponse<FeedbackDto?>
        {
            Data = feedback,Success = true,
        };
    }
}
