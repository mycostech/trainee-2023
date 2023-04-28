using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serverCandidate.Contract;
using serverCandidate.Services;
using serverCandidate.Services.Interfaces;
using static serverCandidate.Data.CandidateContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverCandidate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }


        // GET: api/values
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidate()
        {
            var username = HttpContext?.User?.FindFirst(ClaimTypes.Name);
            var id = HttpContext?.User?.FindFirst(ClaimTypes.Sid);
            var result = await _candidateService.GetCandidate();

            return Ok(result);
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateByID(int id)
        {
            var candidate = await _candidateService.GetCandidateByID(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Candidate>> AddCandidate([FromBody] Candidate candidate)
        {
            var Sid = HttpContext?.User?.FindFirst(ClaimTypes.Sid);
            int id = Convert.ToInt32(Sid.Value);

            return await _candidateService.AddCandidate(candidate, id);
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Candidate>> UpdateCandidate(int id, [FromBody] CandidateUpdatePayload candidate)
        {
            return await _candidateService.UpdateCandidate(id, candidate);
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(int id)
        {
            return await _candidateService.DeleteCandidate(id);
        }
    }
}

