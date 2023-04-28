using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CandidateAPIApplication.Models
{
    public class ResumeCandidateModel
    {
        [Key]
        public int ResumeID { get; set; }

        public string ResumePath { get; set; }
    }
}
