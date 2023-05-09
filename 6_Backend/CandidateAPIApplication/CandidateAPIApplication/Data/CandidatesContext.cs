using CandidateAPIApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Data
{
    public class CandidatesContext: DbContext
    {
        public CandidatesContext() { }

        public CandidatesContext(DbContextOptions<CandidatesContext> option): base(option) { }

        public DbSet<CandidatesModel> CandidatesProfiles { get; set; }
        public DbSet<StatusModel> StatusCandidatesProfiles { get; set; }
        public DbSet<CommentsScoresModel> CommentsAndScoresProfiles { get; set; }
        public DbSet<DateAppointmentsModel> DateAppointmentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<CandidatesModel>()
                .HasIndex(col => col.CandidateId)
                .IsUnique();

            model.Entity<StatusModel>()
                .HasIndex(col=>col.StatusCodeID)
                .IsUnique();

            model.Entity<CommentsScoresModel>()
                .HasIndex(col => col.CommentScoreId)
                .IsUnique();

            model.Entity<DateAppointmentsModel>()
                .HasIndex(col => col.AppointmentID)
                .IsUnique();
        }
    }
}
