using Candidate.API.Models;
using Infrastructure.Response;

namespace Candidate.API.Contracts;

public interface ICandidateRepository
{
    Task<ServiceResponse<CandidateDto>> AddCandidateAsync(CandidateDto candidate);
    Task<ServiceResponse<bool>> UpdateCandidateAsync(int id, CandidateDto candidate);
    Task<ServiceResponse<IEnumerable<CandidateDto>>> GetAllCandidatesAsync();
    Task<ServiceResponse<CandidateDto?>> GetCandidateByIdAsync(int id);
}
