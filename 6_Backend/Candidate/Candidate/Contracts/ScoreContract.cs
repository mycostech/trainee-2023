using Candidate.Data;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Contracts
{
    public class ScoreContract
    {
        public int Experience { get; set; } 
        public int Skill { get; set; } 
        public int Attitude { get; set; }
        public int TeamPlayer { get; set; }
        public int Personality { get; set; }
        public string? Comment { get; set; }
        public float Evaluation { get; set; }
        public Guid UserId { get; set; }

    }
    public class EvaluatioContract
    {
        public float Evaluation { get; set; }
        public Guid UserId { get; set; }
    }
}