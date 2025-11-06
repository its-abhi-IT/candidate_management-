using Interview.API.Contracts;
using Interview.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.API.v1
{
    [ApiController]
    [Route("interviews")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewRepository interviewRepository;

        public InterviewsController(IInterviewRepository interviewRepository)
        {
            this.interviewRepository = interviewRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInterview([FromBody] InterviewDto interview)
        {
            var resp = await interviewRepository.CreateInterviewAsync(interview).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetInterviewById), new { id = interview.Id }, interview);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterviews()
        {
            var interviews = await interviewRepository.GetAllInterviewsAsync();
            return Ok(interviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewById(int id)
        {
            var interview = await interviewRepository.GetInterviewByIdAsync(id);
            if (interview == null) return NotFound();
            return Ok(interview);
        }

        [HttpPost("{id}/feedback")]
        public async Task<IActionResult> SubmitFeedback(int id, [FromBody] FeedbackDto feedback)
        {
            var resp = await interviewRepository.SubmitFeedbackAsync(id,feedback).ConfigureAwait(false);
            if (resp == null)
                return NotFound();

            return Ok(resp);
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetInterviewsByCandidate(int candidateId)
        {
            var interviews = await interviewRepository.GetInterviewByIdAsync(candidateId);
            return Ok(interviews);
        }
    }
}
