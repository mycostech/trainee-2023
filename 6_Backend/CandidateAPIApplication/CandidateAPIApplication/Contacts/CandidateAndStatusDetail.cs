namespace CandidateAPIApplication.Contacts
{
    public class CandidateAndStatusDetail
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;

    }
}
