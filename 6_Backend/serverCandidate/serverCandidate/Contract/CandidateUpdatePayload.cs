using System;
namespace serverCandidate.Contract
{
	public class CandidateUpdatePayload
	{
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? position { get; set; }
        public string? status { get; set; }
        public string? skills { get; set; }
        public string? imageProfile { get; set; }
        public string? resume { get; set; }
        public string? CV { get; set; }
        public string? createAt { get; set; }
    }
}

