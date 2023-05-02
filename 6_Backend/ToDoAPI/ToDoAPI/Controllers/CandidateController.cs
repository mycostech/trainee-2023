
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Controllers
{

    [Route("api/todo")]
    [ApiController]
    [Authorize]
    
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidate()
        {
            return await _candidateService.GetAllCandidate();
        }
        [HttpGet("{CandidateId}")]
        public async Task<ActionResult<Candidate>> GetCandidates(int candidateId)
        {
            var todoItems = await _candidateService.GetCandidates(candidateId);
            if (todoItems == null)
            {
                return NotFound();
            }
            return todoItems;
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> CreateCandidate([FromBody] Candidate candidate)
        {
            return await _candidateService.CreateCandidate(candidate);
        }
        [HttpPut("{CandidateId}")]
        public async Task<ActionResult<Candidate>> UpdateCandidate([FromRoute] int candidateId,Candidate candidate)
        {
            return await _candidateService.UpdateCandidate(candidateId, candidate);
        }
        [HttpDelete("{CandidateId}")]
        public async Task<ActionResult<Candidate>> DeleteCandidates(int CandidateId)
        {
            
  
            return await _candidateService.DeleteCandidate(Convert.ToInt32(CandidateId));
        }

        [HttpGet("status/{StatusId}")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidatesByStatusId(int statusId)
        {
            return await _candidateService.GetCandidatesByStatusId(statusId);
        }

    }
}
