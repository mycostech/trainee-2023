﻿using CandidateAPIApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Data
{
    public class CandidatesContext: DbContext
    {
        public CandidatesContext() { }

        public CandidatesContext(DbContextOptions<CandidatesContext> option): base(option) { }

        public DbSet<CandidatesModel> CandidatesProfile { get; set; }
        public DbSet<StatusModel> StatusCandidateProfile { get; set; }
        public DbSet<CommentsScoresModel> CommentsAndScoresProfile { get; set; }
        public DbSet<CandidatesAndCommentsModel> CandidatesComments { get; set; }
        public DbSet<DateAppointmentsModel> DateAppointmentProfile { get; set; }

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

            model.Entity<CandidatesAndCommentsModel>().HasKey(col => new { col.CandidateId, col.CommentScoreId });

            model.Entity<CandidatesAndCommentsModel>()
                .HasOne<CandidatesModel>(col => col.Candidates)
                .WithMany(col => col.ListCandidateAndComment)
                .HasForeignKey(col => col.CandidateId);

            model.Entity<CandidatesAndCommentsModel>()
                .HasOne<CommentsScoresModel>(col => col.CommentsScores)
                .WithMany(col => col.ListCandidateAndComment)
                .HasForeignKey(col => col.CommentScoreId);

            model.Entity<DateAppointmentsModel>()
                .HasIndex(col => col.AppointmentID)
                .IsUnique();
        }
    }
}
