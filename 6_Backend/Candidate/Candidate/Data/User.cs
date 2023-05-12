using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Candidate.Contracts;
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
        public string? Lastname { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public UrlFile? OwnedFile { get; set; }
        public Score? OwnedScore { get; set; }
        public Picture? OwnedPicture { get; set; }
        public Appointment? OwnedAppointment { get; set; }

        internal object Select(Func<object, EditContract> value)
        {
            throw new NotImplementedException();
        }
    }
}


   


