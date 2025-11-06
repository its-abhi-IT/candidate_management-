using Candidate.API.Contracts;
using Candidate.API.Data;
using Candidate.API.Data.Entity;
using Candidate.API.Models;
using CandidateManagement.Data.Mssql;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Candidate.API.Data.DataManager;

public class CandidateRepository : ICandidateRepository
{
    private readonly IDbFactoryBase<Candidates> candidateRepo;

    public CandidateRepository(IDbFactoryBase<Candidates> candidateRepo)
    {
        this.candidateRepo = candidateRepo;
    }

    public async Task<ServiceResponse<CandidateDto>> AddCandidateAsync(CandidateDto candidate)
    {
        candidate.CreatedOn = DateTime.UtcNow;
        candidate.LastUpdatedOn = DateTime.UtcNow;
        Candidates candidates = new()
        {
            FirstName = candidate.FirstName,
            LastName = candidate.LastName,
            Email = candidate.Email,
            Phone = candidate.Phone,
            ExperienceYears = candidate.ExperienceYears,
            IsActive = candidate.IsActive,
            LastUpdatedOn = candidate.LastUpdatedOn,
            CreatedOn = candidate.CreatedOn,
        };
        await candidateRepo.AddAsync(candidates);
        var response = new ServiceResponse<CandidateDto>();
        response.Data = candidate;
        response.Success = true;
        response.Message = "Candidate added successfully.";
        return response;
    }

    public async Task<ServiceResponse<bool>> UpdateCandidateAsync(int id, CandidateDto candidate)
    {
        var existing = await candidateRepo.GetByIdAsync(id);
        if (existing == null) return new ServiceResponse<bool> { Message ="Not update",Success = false};

        existing.FirstName = candidate.FirstName;
        existing.LastName = candidate.LastName;
        existing.Email = candidate.Email;
        existing.Phone = candidate.Phone;
        existing.ExperienceYears = candidate.ExperienceYears;
        existing.IsActive = candidate.IsActive;
        existing.LastUpdatedOn = DateTime.UtcNow;

        await candidateRepo.UpdateAsync(existing);
       
        return new ServiceResponse<bool>
        {
            Message = " Data Updated",
            Success = true,
        };
    }

    public async Task<ServiceResponse<IEnumerable<CandidateDto>>> GetAllCandidatesAsync()
    {
        var candidates = await candidateRepo.GetAsync(c => c.IsActive == true);
        var result = candidates.Select(c => new CandidateDto
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Phone = c.Phone,
            ExperienceYears = c.ExperienceYears,
            IsActive = c.IsActive,
            LastUpdatedOn = c.LastUpdatedOn,
            CreatedOn = c.CreatedOn
        });

        return new ServiceResponse<IEnumerable<CandidateDto>>
        {
            Data = result,
            Success = true,
            Message = ""
        };
    }

    public async Task<ServiceResponse<CandidateDto?>> GetCandidateByIdAsync(int id)
    {
        var resp = await candidateRepo.GetByIdAsync(id);
         CandidateDto candidate = new()
        {
            Id = resp.Id,
            FirstName = resp.FirstName,
            LastName = resp.LastName,
            Email = resp.Email,
            Phone = resp.Phone,
            ExperienceYears = resp.ExperienceYears,
            IsActive = resp.IsActive,
            LastUpdatedOn = resp.LastUpdatedOn,
            CreatedOn = resp.CreatedOn
        };
        return new ServiceResponse<CandidateDto?>
        {
            Data = candidate,
            Success = true,
        };
    }
}

