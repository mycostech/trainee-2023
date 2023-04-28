using CandidateAPIApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAPIApplication.Services.Interfaces
{
    public interface IStatusCodeServices
    {
        public Task<List<StatusModel>> GetStatusAll();
        public Task<StatusModel> GetStatusByID(int id);
        public Task<IActionResult> PostStatusCode(StatusModel dataStatus);
        public Task<IActionResult> UpdateStatusCode(int id, string statusDescription);
        public Task<IActionResult> DeleteStatusCode(int id);

    }
}
