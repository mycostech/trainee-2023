using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidate.Data
{
    public class Picture
    {
        public string? Image { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public User? UserPicture { get; set; }
    }
}