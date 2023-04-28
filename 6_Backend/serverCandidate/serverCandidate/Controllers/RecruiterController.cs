using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serverCandidate.Contract;
using serverCandidate.Services;
using serverCandidate.Services.Interfaces;
using static serverCandidate.Data.CandidateContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverCandidate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {

        private readonly IRecruiterService _recruiterService;

        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recruiter>>> GetRecruiter()
        {
            var result = await _recruiterService.GetRecruiter();

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recruiter>> GetRecruiterByID(int id)
        {
            var recruters = await _recruiterService.GetRecruiterByID(id);
            if (recruters == null)
            {
                return NotFound();
            }

            return recruters;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Recruiter>> AddRecruiter([FromBody] Recruiter recruiter)
        {
            return await _recruiterService.AddRecruiter(recruiter);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Recruiter>> UpdateRecruiter(int id, [FromBody] RecruiterUpdatePayload recruiter)
        {
            return await _recruiterService.UpdateRecruiter(id, recruiter);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recruiter>> DeleteRecruiter(int id)
        {
            return await _recruiterService.DeleteRecruiter(id);
        }

        // REGISTER
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterContract model)
        {
            try
            {
                string message = await _recruiterService.Register(model);
                return Ok(message);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
        }

        // LOGIN
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var userToken = await _recruiterService.Login(username, password);
                return Ok(userToken);
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message);
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
        }
    }
}

