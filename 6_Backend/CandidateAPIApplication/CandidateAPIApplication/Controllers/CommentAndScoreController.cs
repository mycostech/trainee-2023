using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentAndScoreController: ControllerBase
    {
        public readonly ICommentAndScoreServices _servicesCommentScore;

        public CommentAndScoreController(ICommentAndScoreServices servicesCommentScore)
        {
            _servicesCommentScore = servicesCommentScore;
        }

        [HttpGet]
        public async Task<List<CommentsScoresModel>> GetAllCommentScore()
        {
            return await _servicesCommentScore.GetAllCommentAndScores();
        }

        [HttpGet("{id}")]
        public async Task<CommentsScoresModel> GetCommentScoreById([FromRoute] int id)
        {
            return await _servicesCommentScore.GetCommentAndScoreByID(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentScoreById([FromRoute] int id, [FromBody] CommentsScoresModel dataCommentScore)
        {
            await _servicesCommentScore.UpdateCommentAndScore(id, dataCommentScore);
            return Ok(dataCommentScore);
        }

        [HttpPut]
        public async Task<IActionResult> CreateCommentScore([FromBody] CommentsScoresModel dataCommentScore)
        {
            await _servicesCommentScore.CreateCommentAndScore(dataCommentScore);
            return Ok(dataCommentScore);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentScoreById([FromRoute] int id)
        {
            await _servicesCommentScore.DeleteCommentAndScore(id);
            return Ok();
        }

        [HttpGet("Candidate/{id}")]
        public async Task<List<CommentsScoresModel>> GetAllCommentAndScoreByCandidateId([FromRoute] int id)
        {
            return await _servicesCommentScore.GetAllCommentAndScoresByCandidateId(id);
        } 
    }
}
