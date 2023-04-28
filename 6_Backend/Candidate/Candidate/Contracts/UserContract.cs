using System;
using System.ComponentModel.DataAnnotations;
using Candidate.Data;

namespace Candidate.Contracts
{
    public class UserContract
    {
        //public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UrlFileContract? UrlFile { get; set; }
    }
}

