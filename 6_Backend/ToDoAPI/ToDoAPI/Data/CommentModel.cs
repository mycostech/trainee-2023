using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Data
{
    public class Commentinfo
    {
            [Key]
            public int CommentId { get; set; }
            public string cComment { get; set; }

            public string cCommentDate { get; set; }

            [ForeignKey(nameof(CandidateId))]
            public int CandidateId { get; set; }
            //public Candidate Candidate { get; set; }
       
    }
}
