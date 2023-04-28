using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidate.Data
{
    public class UrlFile
    {

        public string? File { get; set; } = null; 
        [Key]
        public Guid UserId { get; set; }
        public User User_File { get; set; }

    }
}