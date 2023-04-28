using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CandidateAPIApplication.Models
{
    public class DateAppointmentsModel
    {
        [Key]
        public int AppointmentID { get; set; }

        public string StartAppointment { get; set; }
        public string EndAppointment { get; set; }
    }
}
