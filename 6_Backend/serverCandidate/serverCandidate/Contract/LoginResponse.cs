using System;
namespace serverCandidate.Contract
{
	public class LoginResponse
	{
        public string Token { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}

