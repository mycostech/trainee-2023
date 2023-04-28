
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Controllers
{

    [Route("api/todo")]
    [ApiController]
    [Authorize]
    
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _todoService;
        public CandidateController(ICandidateService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidate()
        {
            return await _todoService.GetAllCandidate();
        }
        [HttpGet("{CandidateId}")]
        public async Task<ActionResult<Candidate>> GetCandidates(int CandidateId)
        {
            var todoItems = await _todoService.GetCandidates(CandidateId);
            if (todoItems == null)
            {
                return NotFound();
            }
            return todoItems;
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> CreateCandidate([FromBody] Candidate candidate)
        {
            return await _todoService.CreateCandidate(candidate);
        }
        [HttpPut("{CandidateId}")]
        public async Task<ActionResult<Candidate>> UpdateCandidate([FromRoute] int CandidateId,Candidate candidate)
        {
            return await _todoService.UpdateCandidate(CandidateId, candidate);
        }
        [HttpDelete("{CandidateId}")]
        public async Task<ActionResult<Candidate>> DeleteCandidates(string CandidateId)
        {
            
            if (CandidateId == "")
            {
                return NotFound();
            }
            return await _todoService.DeleteCandidate(Convert.ToInt32(CandidateId));
        }
        [HttpGet("status/{statusId}")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidatesByStatusId(int statusId)
        {
            return await _todoService.GetCandidatesByStatusId(statusId);
        }
        [HttpGet("evaluations/{candidateId}")]
        public async Task<ActionResult<List<Evaluation>>> GetEvaluationsByCandidateId(int candidateId)
        {
            var evaluations = await _todoService.GetEvaluationsByCandidateId(candidateId);
            if (evaluations == null || evaluations.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return evaluations;
            }
        }
    }
}
