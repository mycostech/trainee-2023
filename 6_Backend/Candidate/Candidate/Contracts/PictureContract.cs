using Candidate.Data;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Contracts
{
    public class PictureContract
    {
        public string? Image { get; set; }
        public Guid UserId { get; set; }

    }
}