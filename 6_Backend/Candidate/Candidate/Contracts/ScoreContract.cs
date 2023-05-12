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

    public class EditScore
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; }
        public ScoreContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        public UrlFileContract? UrlFile { get; set; }
        public AppointmentContract? Appointment { get; set; }
    }

}