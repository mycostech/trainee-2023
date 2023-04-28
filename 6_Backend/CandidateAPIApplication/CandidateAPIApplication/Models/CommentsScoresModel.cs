using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateAPIApplication.Models
{
    public class CommentsScoresModel
    {
        [Key]
        public int CommentScoreID { get; set; }


        public string Comments { get; set; }

        public int Scores { get; set; }
    }
}
