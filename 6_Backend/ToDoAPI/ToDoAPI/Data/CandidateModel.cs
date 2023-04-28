using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Data
{
    public class CandidateModel : DbContext
    {
        public CandidateModel() { }

        public CandidateModel(DbContextOptions<CandidateModel> options)
            : base(options)
        {

        }

        #region table
        public DbSet<Candidate> Candidate { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Commentinfo> Commentinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(s => s.UserName)
                .IsUnique();
        }

        #endregion
    }
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public string Attitude { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string Personality { get; set; }
        public string cInputDate { get; set; }
        public string cAppointment { get; set; }

        //public ICollection<Commentinfo> Commentinfo { get; set; }
    }
}
