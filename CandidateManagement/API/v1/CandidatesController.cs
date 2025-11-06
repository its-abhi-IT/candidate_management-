using Candidate.API.Contracts;
using Candidate.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.API.API.v1;

[ApiController]
[Route("candidates")]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateRepository _repository;

    public CandidatesController(ICandidateRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCandidate([FromBody] CandidateDto candidate)
    {
        var created = await _repository.AddCandidateAsync(candidate);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCandidate(int id, [FromBody] CandidateDto candidate)
    {
        var updated = await _repository.UpdateCandidateAsync(id, candidate);
        if (updated == null)
            return NotFound();
        return Ok(updated);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCandidates()
    {
        var candidates = await _repository.GetAllCandidatesAsync();
        return Ok(candidates);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCandidateById(int id)
    {
        var candidate = await _repository.GetCandidateByIdAsync(id);
        if (candidate == null)
            return NotFound();
        return Ok(candidate);
    }
}
