using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CandidateAPIApplication.Models
{
    public class DateAppointmentsModel
    {
        [Key]
        public int AppointmentID { get; set; }

        //[ForeignKey(nameof(CandidateProfile))]
        //public int CandidateID { get; set; }
        //public CandidatesModel CandidateProfile { get; set; }
        public string? StartAppointment { get; set; }
        public string? EndAppointment { get; set; }

        [JsonIgnore]
        public List<CandidatesModel>? ListCandidate { get; set; }

    }
}
