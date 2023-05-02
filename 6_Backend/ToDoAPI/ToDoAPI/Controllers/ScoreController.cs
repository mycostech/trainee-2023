using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Controllers
{
    [Route("api/score")]
    [ApiController]
    //[Authorize]
    public class ScoreController : ControllerBase
    {
        
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet("{candidateId}")]
        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluationByCandidateId(int candidateId)
        {
            var evaluation = await _scoreService.GetEvaluationByCandidateId(candidateId);
            if (evaluation == null)
            {
                return NotFound();
            }

            return evaluation;
        }

        [HttpPut("{CandidateId}")]
        public async Task<ActionResult<Evaluation>> UpdateScore([FromRoute] int CandidateId, Evaluation evaluation)
        {
            try
            {
                var eva = await _scoreService.UpdateScore(CandidateId, evaluation);
                return eva;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{candidateId}/{score}/{scoreTypeDescription}")]
        public async Task<ActionResult<Evaluation>> InsertScore(int candidateId, int score, string scoreTypeDescription)
        {
            try
            {
                var evaluation = await _scoreService.InsertScore(candidateId, score, scoreTypeDescription);
                return CreatedAtAction(nameof(GetEvaluationByCandidateId), new { candidateId = evaluation.CandidateId }, evaluation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}