using System;
namespace serverCandidate.Contract
{
	public class RegisterContract
	{
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string position { get; set; } = string.Empty;
        public string imageProfile { get; set; } = string.Empty;
        public string createAt { get; set; } = string.Empty;
        public string? updateAt { get; set; }
    }
}

