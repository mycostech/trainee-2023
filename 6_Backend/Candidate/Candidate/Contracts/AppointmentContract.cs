using System.ComponentModel.DataAnnotations;

namespace Candidate.Contracts
{
    public class AppointmentContract
    {
        public DateTime? Meet { get; set; }
        public Guid UserId { get; set; }
    }
}