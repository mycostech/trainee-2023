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
        [HttpGet("Total")]
        public List<TotalContract> Total()
        {
            var result = _todoService.GetTotal();
            return result;
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

        [HttpGet("SortInterview")]
        public List<InterviewContract> SortInterview()
        {
            var result = _todoService.GetSortInterview();
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

        [HttpGet("User")]
        public List<EditScore> EditScore(Guid id)
        {
            var result = _todoService.GetEditScore(id);
            return result;
        }

        [HttpPut("Update")]
        public async Task<EditContract> UpdateCandidate([FromBody] EditContract contract)
        {
            var result = await _todoService.UpdateCandidate(contract);
            return result;
        }

        [HttpPost("CreateUser")]
        public async Task<CreateContract> CreateUser([FromBody] CUContract contract)
        {
            var result = await _todoService.CreateUser(contract);
            return result;
        }

        [HttpDelete("{id}")]
        public Task<UserAccount> DeleteUser(Guid id)
        {
            var result = _todoService.DeleteUser(id);
            return result;
        }
    }
}

