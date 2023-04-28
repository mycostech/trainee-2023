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
        public DbSet<Notification> Notifications { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .Entity<User>()
                .HasOne(e => e.OwnedFile)
                .WithOne(e => e.User_File)
                .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .Entity<Score>()
            //    .HasOne(e => e.User_Score)
            //    .WithOne(e => e.OwnedScore)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .Entity<Picture>()
            //    .HasOne(e => e.User_Picture)
            //    .WithOne(e => e.OwnedPicture)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .Entity<Notification>()
            //    .HasOne(e => e.User_Notification)
            //    .WithOne(e => e.OwnedNotification)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .Entity<Appointment>()
            //    .HasOne(e => e.User_Appointment)
            //    .WithOne(e => e.User_Appointment)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}




