using System;
namespace Candidate.Contracts
{
	public class EditContract
	{
        public Guid Id { get; set; }
        public int? Status { get; set; }
        public int Experience { get; set; }
        public int Skill { get; set; }
        public int Attitude { get; set; }
        public int TeamPlayer { get; set; }
        public int Personality { get; set; }
        public string? Comment { get; set; }
        public float Evaluation { get; set; }
        public string? Meet { get; set; }
        //public UrlFileContract? UrlFile { get; set; }
        //public ScoreContract? Score { get; set; }
        //public PictureContract? Picture { get; set; }
        //public AppointmentContract? Appointment { get; set; }
    }
}

