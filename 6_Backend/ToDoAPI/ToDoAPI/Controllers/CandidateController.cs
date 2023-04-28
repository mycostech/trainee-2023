using CandidateHW.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoAPI.Data;

namespace CandidateHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServices _candidateService;

        public CandidateController(ICandidateServices candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidate()
        {
            var a = await _candidateService.GetAllCandidate();
            return Ok(a);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidateUserId()
        //{
        //    var username = HttpContext?.User?.FindFirst(ClaimTypes.Name);
        //    var id  = HttpContext?.User?.FindFirst(ClaimTypes.Sid);
        //    var a = await _candidateService.GetAllCandidate();

        //    return Ok(a);
        //}

        [HttpPost]
        public async Task<ActionResult<Candidate>> CreateCandiate([FromBody] Candidate contract)
        {
            return await _candidateService.CreateCandiate(contract);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Candidate>> UpdateCandidate([FromBody] Candidate contract, int id)
        {
            return await _candidateService.UpdateCandidate(id, contract);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate([FromBody] string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return await _candidateService.DeleteCandidate(Convert.ToInt32(id));
        }
    }
}
