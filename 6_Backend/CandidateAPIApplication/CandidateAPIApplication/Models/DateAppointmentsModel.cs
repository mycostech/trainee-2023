using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CandidateAPIApplication.Models
{
    public class DateAppointmentsModel
    {
        [Key]
        public int AppointmentID { get; set; }
        public int CandidateId { get; set; }
        public string? StartAppointment { get; set; }
        public string? EndAppointment { get; set; }

    }
}
