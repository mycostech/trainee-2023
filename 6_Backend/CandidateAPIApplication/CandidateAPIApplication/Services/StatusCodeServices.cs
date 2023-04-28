using CandidateAPIApplication.Data;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Services
{
    public class StatusCodeServices : IStatusCodeServices
    {
        public readonly CandidatesContext _contextCandidate;

        public StatusCodeServices(CandidatesContext contextCandidate)
        {
            _contextCandidate = contextCandidate;
        }

        public Task<IActionResult> DeleteStatusCode(int id)
        {

            throw new NotImplementedException();
        }

        public async Task<List<StatusModel>> GetStatusAll()
        {
            return await _contextCandidate.StatusCandidateProfile.ToListAsync();
        }

        public async Task<StatusModel> GetStatusByID(int id)
        {
            var findData = await _contextCandidate.StatusCandidateProfile.FirstAsync(i=>i.StatusCodeID == id);
            if (findData != null)
            {
                return findData;
            }
            return null;
        }

        public Task<IActionResult> PostStatusCode(StatusModel dataStatus)
        {

            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateStatusCode(int id, string statusDescription)
        {
            throw new NotImplementedException();
        }
    }
}
