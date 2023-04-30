using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateAPIApplication.Models
{
    public class CandidatesAndCommentsModel
    {
        [Key]
        public int CandidatesAndCommentsId { get; set; }

        public int CandidateId { get; set; }
        public CandidatesModel? Candidates { get; set; }

        public int CommentScoreId { get; set; }
        public CommentsScoresModel? CommentsScores { get; set; }
    }
}
