namespace CandidateAPIApplication.Contacts
{
    public class CandidateUploadData
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ResumeName { get; set; } = string.Empty;
        public IFormFile? ResumeFile { get; set; } 
        public string ImageName { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }

    }
}
