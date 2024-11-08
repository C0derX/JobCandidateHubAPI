using CandidateApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateApi.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate);

    }
}
