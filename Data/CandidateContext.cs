using Microsoft.EntityFrameworkCore;
using CandidateApi.Models;

namespace CandidateApi.Data
{
    public class CandidateContext : DbContext
    {
        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
