using CandidateAPIApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Data
{
    public class CandidatesContext: DbContext
    {
        public CandidatesContext() { }

        public CandidatesContext(DbContextOptions<CandidatesContext> option): base(option) { }

        public DbSet<CandidatesModel> CandidatesProfile { get; set; }
        public DbSet<StatusModel> StatusCandidateProfile { get; set; }

    }
}
