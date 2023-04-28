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
    }
}
