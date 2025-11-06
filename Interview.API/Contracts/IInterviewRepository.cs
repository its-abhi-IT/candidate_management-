using Infrastructure.Response;
using Interview.API.Model;

namespace Interview.API.Contracts;

public interface IInterviewRepository
{
    Task<ServiceResponse<InterviewDto>> CreateInterviewAsync(InterviewDto InterviewDto);
    Task<ServiceResponse<InterviewDto[]>> GetAllInterviewsAsync();
    Task<ServiceResponse<InterviewDto?>> GetInterviewByIdAsync(int id);
    Task<ServiceResponse<InterviewDto[]>> GetInterviewsByCandidateIdAsync(int candidateId);
    Task<ServiceResponse<FeedbackDto?>> SubmitFeedbackAsync(int interviewId, FeedbackDto feedback);
}
