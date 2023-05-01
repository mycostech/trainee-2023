using CandidateAPIApplication.Models;

namespace CandidateAPIApplication.Services.Interfaces
{
    public interface ICommentAndScoreServices
    {
        public Task<List<CommentsScoresModel>> GetAllCommentAndScores();
        public Task<CommentsScoresModel> GetCommentAndScoreByID(int id);
        public Task CreateCommentAndScore(CommentsScoresModel dataCommentScore);
        public Task UpdateCommentAndScore(int id, CommentsScoresModel dataCommentScore);
        public Task DeleteCommentAndScore(int id);
    }
}
