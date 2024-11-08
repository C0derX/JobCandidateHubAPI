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
    }
}
