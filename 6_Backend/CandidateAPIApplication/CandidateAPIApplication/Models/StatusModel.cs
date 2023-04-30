using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CandidateAPIApplication.Models
{
    public class StatusModel
    {
        [Key,NotNull]
        public int StatusCodeID { get; set; }

        public string? StatusDescription { get; set; }

        [JsonIgnore]
        public List<CandidatesModel>? ListCandidates { get; set; } 
    }
}
