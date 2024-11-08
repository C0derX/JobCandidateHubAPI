using CandidateApi.Models;
using CandidateApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateService _candidateService;

        public CandidatesController(CandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // POST: api/candidates
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateCandidate([FromBody] Candidate candidate)
        {
            try
            {
                if (candidate == null)
                {
                    return BadRequest("Candidate data is null.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); 
                }

                var result = await _candidateService.CreateOrUpdateCandidateAsync(candidate);

                return Ok(result); 
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/candidates
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            try
            {
                var candidates = await _candidateService.GetAllCandidatesAsync();

                if (candidates == null || candidates.Count == 0)
                {
                    return NotFound("No candidates found.");
                }

                return Ok(candidates); // Returns the list of candidates
            }
            catch (System.Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/candidates/{email}
        [HttpGet("{email}")]
        public async Task<IActionResult> GetCandidateByEmail(string email)
        {
            try
            {
                var candidate = await _candidateService.GetCandidateByEmailAsync(email);

                if (candidate == null)
                {
                    return NotFound($"Candidate with email {email} not found.");
                }

                return Ok(candidate); // Returns the candidate if found
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
