using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CandidateAPIApplication.Models
{
    public class StatusModel
    {
        [Key]
        public int StatusCodeID { get; set; }

        public string StatusDescription { get; set; }
    }
}
