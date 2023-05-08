using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CandidateAPIApplication.Models
{
    public class CandidatesModel
    {
        [Key]
        public int CandidateId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? PathImage { get; set; }
        public string? PathResume { get; set; }

        [JsonIgnore]
        public int? DateAppointmentId { get; set; }

        [JsonIgnore]
        public DateAppointmentsModel? DateAppointments { get; set; }

        public int StatusCodeID { get; set; }

        [JsonIgnore]
        public List<CandidatesAndCommentsModel>? ListCandidateAndComment { get; set; } 
    }
}
