using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPI.Data
{
    public class CandidateContext : DbContext
    {
        public CandidateContext() { }
        public CandidateContext(DbContextOptions<CandidateContext> options)
            : base(options)
        {

        }
        #region tables
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<Evaluation> Evaluation { get; set; }
        #endregion
    }
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [ForeignKey(nameof(StatusID))]
        public int StatusID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public string InterviewDate { get; set; }

        public string PhoneNumber { get; set; }
    }
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        public string StatusDescription { get; set; }
    }
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }

        [ForeignKey(nameof(Candidate))]
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }

        public int ScoreType { get; set; }

        public int Score { get; set; }

        public string ScoreTypeDescription { get; set; }
    }

}
