using System.ComponentModel.DataAnnotations;

namespace Candidate.Data
{
    public class Notification
    {
        public DateTime Warn { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public User User_Notification { get; set; }
    }
}