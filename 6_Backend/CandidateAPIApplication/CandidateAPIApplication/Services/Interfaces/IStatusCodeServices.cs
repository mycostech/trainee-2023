using CandidateAPIApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAPIApplication.Services.Interfaces
{
    public interface IStatusCodeServices
    {
        public Task<List<StatusModel>> GetStatusAll();
        public Task<StatusModel> GetStatusByID(int id);
        public Task PostStatusCode(StatusModel dataStatus);
        public Task UpdateStatusCode(int id, string statusDescription);
        public Task DeleteStatusCode(int id);
        public Task<List<CandidatesModel>> GetAllCandidateHasStatusByID(int id);
    }
}
