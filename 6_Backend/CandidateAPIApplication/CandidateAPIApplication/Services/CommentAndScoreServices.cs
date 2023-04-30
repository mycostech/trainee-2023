using CandidateAPIApplication.Data;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Services
{
    public class CommentAndScoreServices : ICommentAndScoreServices
    {
        public readonly CandidatesContext _contexComment;

        public CommentAndScoreServices(CandidatesContext contexComment)
        {
            _contexComment = contexComment;
        }
        public async Task CreateCommentAndScore(CommentsScoresModel dataCommentScore)
        {
            try
            {
                await _contexComment.CommentsAndScoresProfile.AddAsync(dataCommentScore);
                await _contexComment.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCommentAndScore(int id)
        {
            try
            {
                var findData = await _contexComment.CommentsAndScoresProfile.FindAsync(id);
                _contexComment.CommentsAndScoresProfile.Remove(findData);
                await _contexComment.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CommentsScoresModel>> GetAllCommentAndScores()
        {
            return await _contexComment.CommentsAndScoresProfile.ToListAsync();
        }

        public async Task<CommentsScoresModel> GetCommentAndScoreByID(int id)
        {
            try
            {
                var fineData = await _contexComment.CommentsAndScoresProfile.FirstOrDefaultAsync(i => i.CommentScoreId == id);
                return fineData;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task UpdateCommentAndScore(int id, CommentsScoresModel dataCommentScore)
        {
            try
            {
                var findData = await _contexComment.CommentsAndScoresProfile.FirstOrDefaultAsync(i=>i.CommentScoreId == id);
                findData.Comments = dataCommentScore.Comments;
                findData.Scores = dataCommentScore.Scores;
                _contexComment.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
