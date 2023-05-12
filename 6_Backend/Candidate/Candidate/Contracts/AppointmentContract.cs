using System.ComponentModel.DataAnnotations;

namespace Candidate.Contracts
{
    public class AppointmentContract
    {
        public string? Meet { get; set; }
        public Guid UserId { get; set; }
    }
}