using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Candidate.Data
{
    public class Score
    {
        public int Experience { get; set; }
        public int Skill { get; set; }
        public int Attitude { get; set; }
        public int TeamPlayer { get; set; }
        public int Personality { get; set; }
        public string? Comment { get; set; }
        public float Evaluation { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public User? UserScore { get; set; }
    }
}