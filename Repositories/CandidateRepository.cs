using CandidateApi.Data;
using CandidateApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateApi.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateContext _context;

        public CandidateRepository(CandidateContext context)
        {
            _context = context;
        }

        public async Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await _context.Candidates
                .FirstOrDefaultAsync(c => c.Email == candidate.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.TimeIntervalToCall = candidate.TimeIntervalToCall;
                existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                existingCandidate.GitHubProfile = candidate.GitHubProfile;
                existingCandidate.Comment = candidate.Comment;

                await _context.SaveChangesAsync();
                return existingCandidate;
            }
            else
            {
                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
                return candidate;
            }
        }
    }
}
