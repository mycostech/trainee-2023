using System;
using System.ComponentModel.DataAnnotations;

namespace serverCandidate.Contract
{
	public class RecruiterUpdatePayload
	{
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? position { get; set; }
        public string? imageProfile { get; set; }
        public string? createAt { get; set; }
    }
}

