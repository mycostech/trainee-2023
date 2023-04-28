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
        private readonly ITodoService _todoService;

        public CandidateController(ITodoService todoService)
        {
            _todoService = todoService;

        }
        [HttpGet("Dashboard")]
        public  List<UserContract> Dashboard()
        {
            var result =  _todoService.GetUser();
            return result;
        }
        [HttpPost("CreateUser")]
        public async Task<UserContract> CreateUser([FromBody] UserContract contract)
        {
            var result = await _todoService.CreateUser(contract);
            return result;
        }
    }
}

