using System;
using Candidate.Contracts;
using Candidate.Data;
using Candidate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
	{
        private readonly ICandidateService _todoService;

        public CandidateController(ICandidateService todoService)
        {
            _todoService = todoService;

        }

        [HttpGet("Dashboard")]
        public  List<DashboardContract> Dashboard()
        {
            var result =  _todoService.GetDashboard();
            return result;
        }

        [HttpGet("Applied")]
        public List<AppliedContract> Applied()
        {
            var result = _todoService.GetApplied();
            return result;
        }

        [HttpGet("Accept")]
        public List<AcceptContract> Accept()
        {
            var result = _todoService.GetAccept();
            return result;
        }

        [HttpGet("Interview")]
        public List<InterviewContract> Interview()
        {
            var result = _todoService.GetInterview();
            return result;
        }

        [HttpGet("Disqualified")]
        public List<DisqualifiedContract> Disqualified()
        {
            var result = _todoService.GetDisqualified();
            return result;
        }

        [HttpGet("Hired")]
        public List<HiredContract> Hired()
        {
            var result = _todoService.GetHired();
            return result;
        }

        [HttpPut("/User/{id}")]
        public async Task<EditContract> UpdateCandidate([FromBody] EditContract contract,Guid id)
        {
            var result = await _todoService.UpdateCandidate(contract, id);
            return result;
        }

        [HttpPost("CreateUser")]
        public async Task<CreateContract> CreateUser([FromBody] CreateContract contract)
        {
            var result = await _todoService.CreateUser(contract);
            return result;
        }

        [HttpDelete("{id}")]
        public Task<UserAccount> DeleteUser(UserAccount id)
        {
            var result = _todoService.DeleteUser(id);
            return result;
        }
    }
}

