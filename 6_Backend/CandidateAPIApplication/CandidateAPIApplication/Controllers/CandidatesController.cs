using CandidateAPIApplication.Contacts;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CandidateAPIApplication.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateServices _servicesCandidate;
        public CandidatesController(ICandidateServices servicesCandidate)
        {
            _servicesCandidate = servicesCandidate;
        }

        [HttpGet]
        public async Task<List<CandidatesModel>> GetAllCandidateProfiles()
        {
            return await _servicesCandidate.GetAllCandidate();
        }

        [HttpGet("{id}")]
        public async Task<CandidatesModel> GetCandidateByID([FromRoute] int id)
        {
            var findData = await _servicesCandidate.GetCandidatesByID(id);
            return findData;
        }

        [HttpPost]
        public async Task<IActionResult> PostCandidateProfile([FromForm] CandidateUploadData dataCandidate)
        {
            await _servicesCandidate.CreateCandidate(dataCandidate);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateProfileByID([FromRoute] int id)
        {
            await _servicesCandidate.DeleteCandidateByID(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidateProfileByID([FromRoute] int id, [FromBody] CandidatesModel dataCandidate)
        {
            await _servicesCandidate.UpdateCandidate(id, dataCandidate);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string firstName, string lastName, string email)
        {
            try
            {
                var userToken = await _servicesCandidate.Login(firstName, lastName, email);
                return Ok(userToken);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ex.Message);
            }
        }

        [HttpPut("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterContact dataRegis)
        {
            try
            {
                await _servicesCandidate.Register(dataRegis);
                return Ok("User create success.");
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ex.Message);
            }
        }

        [HttpGet("Detail/{id}")]
        public async Task<CandidateAndStatusDetail> GetCandidateAndDetail([FromRoute] int id)
        {
            return await _servicesCandidate.GetCandidateAndStatus(id);
        }

        [HttpGet("Detail")]
        public async Task<List<CandidateAndStatusDetail>> GetAllCandidateAndDetail()
        {
            return await _servicesCandidate.GetAllCandidateAndStatus();
        }

        [HttpPut("ChangeStatusCode/{id}")]
        public async Task<IActionResult> ChangeCandidateStatus([FromRoute] int id, [FromBody] int statusCode)
        {
            await _servicesCandidate.ChangeStatusCode(id,statusCode);
            return Ok();
        }
    }
}
