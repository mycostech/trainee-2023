using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
//using serverCandidate.Models;

namespace serverCandidate.Data
{
	public class CandidateContext : DbContext
	{
		public CandidateContext()
		{
		}
        public CandidateContext(DbContextOptions<CandidateContext> options)
            : base(options)
        {
        }

        #region tables
        //public DbSet<TodoItem> TodoItems { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Recruiter>()
                .HasIndex(s => s.username)
                .IsUnique();

            // new User().UserName = null;
        }

        public class Recruiter
        {
            [Required, Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int idRecruiter { get; set; }
            [Required]
            [MaxLength(20)]
            public string username { get; set; } = string.Empty;
            public string password { get; set; } = string.Empty;

            public string firstName { get; set; } = string.Empty;
            public string lastName { get; set; } = string.Empty;
            public string email { get; set; } = string.Empty;
            public string position { get; set; } = string.Empty;
            public string imageProfile { get; set; } = string.Empty;
            public string createAt { get; set; } = string.Empty;
            public string? updateAt { get; set; }
            
        }

        public class Candidate
        {
            [Key]
            public int idCandidate { get; set; }
            public string firstName { get; set; } = string.Empty;
            public string lastName { get; set; } = string.Empty;
            public string email { get; set; } = string.Empty;
            public string position { get; set; } = string.Empty;
            public string status { get; set; } = string.Empty;
            public string skills { get; set; } = string.Empty;
            public string imageProfile { get; set; } = string.Empty;          
            public string? resume { get; set; } 
            public string? CV { get; set; }
            public int? rating { get; set; } // points for each candidate
            public string createAt { get; set; } = string.Empty;
            public string? updateAt { get; set; }

            [ForeignKey(nameof(Recruiter))]
            public int idRecruiter { get; set; }
            public Recruiter? Recruiter { get; set; }
        }

        public class Comment
        {
            [Key]
            public int idComment { get; set; }
            public string message { get; set; } = string.Empty;
            public string createAt { get; set; } = string.Empty;
            public string? updateAt { get; set; }

            [ForeignKey(nameof(Recruiter))]
            public int idRecruiter { get; set; }
            public Recruiter? Recruiter { get; set; }

            [ForeignKey(nameof(Candidate))]
            public int idCandidate { get; set; }
            public Recruiter? Candidate { get; set; }
        }

        public class Appointment
        {
            [Key]
            public int idAppointment { get; set; }
            public string title { get; set; } = string.Empty;
            public string candidateName { get; set; } = string.Empty;
            public string position { get; set; } = string.Empty;
            public string dateOfAppointment { get; set; } = string.Empty;
            public string recruiterName { get; set; } = string.Empty;
            public string createAt { get; set; } = string.Empty;
            public string? updateAt { get; set; }

            [ForeignKey(nameof(Recruiter))]
            public int idRecruiter { get; set; }
            public Recruiter? Recruiter { get; set; }

            [ForeignKey(nameof(Candidate))]
            public int idCandidate { get; set; }
            public Recruiter? Candidate { get; set; }
        }
    }
}

