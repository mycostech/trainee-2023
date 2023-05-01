using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusCodesController : ControllerBase
    {
        private readonly IStatusCodeServices _servicesStatus;

        public StatusCodesController(IStatusCodeServices servicesStatus)
        {
            _servicesStatus = servicesStatus;
        }

        [HttpGet]
        public async Task<List<StatusModel>> GetAllStatusCodes()
        {
            return await _servicesStatus.GetStatusAll();
        }

        [HttpGet("{id}")]
        public async Task<StatusModel> GetStatusCodesByID([FromRoute] int id)
        {
            var findData = await _servicesStatus.GetStatusByID(id);
            return findData;
        }

        [HttpPut]
        public async Task<IActionResult> CreateStatusCodes([FromBody] StatusModel statusDescript)
        {
            await _servicesStatus.PostStatusCode(statusDescript);
            return Ok(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusCodeByID([FromRoute] int id)
        {
            await _servicesStatus.DeleteStatusCode(id);
            return Ok(200);
        }

        [HttpGet("CandidatesHasStatus/{id}")]
        public async Task<List<CandidatesModel>> GetAllCandidateHasStatusCodeID([FromRoute] int id)
        {
            return await _servicesStatus.GetAllCandidateHasStatusByID(id);
        }
    }
}
