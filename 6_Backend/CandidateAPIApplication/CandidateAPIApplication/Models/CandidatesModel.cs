using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CandidateAPIApplication.Models
{
    public class CandidatesModel
    {
        [Key]
        public int CandidateId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [ForeignKey(nameof(StatusCodes))]
        public int StatusCodeID { get; set; }
        public StatusModel StatusCodes { get; set; }
    }
}
