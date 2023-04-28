using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Data
{
    public class User
    {
        [Required, Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Description { get; set; }
        [Required]
        public string Position { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public UrlFile? OwnedFile { get; set; }
        //public Score OwnedScore { get; set; }
        //public Picture OwnedPicture { get; set; }
        //public Notification OwnedNotification { get; set; }
        //public Appointment User_Appointment { get; set; }
    }
}


   


