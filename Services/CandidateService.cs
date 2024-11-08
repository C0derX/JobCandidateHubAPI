using CandidateApi.Models;
using CandidateApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateApi.Services
{
    public class CandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate)
        {
            return await _candidateRepository.CreateOrUpdateCandidateAsync(candidate);
        }

        public async Task<List<Candidate>> GetAllCandidatesAsync()
        {
            return await _candidateRepository.GetAllCandidatesAsync();
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _candidateRepository.GetCandidateByEmailAsync(email);
        }
    }
}
