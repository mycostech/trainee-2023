using System;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Candidate.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Candidate.Data
{
	public class TodoItemsContext : DbContext
	{
        public TodoItemsContext(DbContextOptions<TodoItemsContext> options)
            : base(options)
        {

        }
        #region tables 
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<UrlFile> UrlFiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .Entity<User>()
                .HasOne(e => e.OwnedFile)
                .WithOne(e => e.UserFile)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Entity<User>()
                .HasOne(e => e.OwnedScore)
                .WithOne(e => e.UserScore)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Entity<User>()
                .HasOne(e => e.OwnedPicture)
                .WithOne(e => e.UserPicture)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Entity<User>()
                .HasOne(e => e.OwnedAppointment)
                .WithOne(e => e.UserAppointment)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}




