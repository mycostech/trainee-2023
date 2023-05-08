using CandidateAPIApplication.Contacts;
using CandidateAPIApplication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CandidateAPIApplication.Services.Interfaces
{
    public interface ICandidateServices
    {
        public Task<List<CandidatesModel>> GetAllCandidate();
        public Task<CandidatesModel> GetCandidatesByID(int id);
        public Task CreateCandidate(CandidateUploadData dataCandidate);
        public Task UpdateCandidate(int id, CandidatesModel dataCandidate);
        public Task DeleteCandidateByID(int id);
        public Task Register(RegisterContact dataRegister);
        public Task<LoginResponse> Login(string firstName, string lastName, string email);
        public JwtSecurityToken GetToken(List<Claim> authClaim);
        public Task<CandidateAndStatusDetail> GetCandidateAndStatus(int id);
        public Task<List<CandidateAndStatusDetail>> GetAllCandidateAndStatus();
        public Task ChangeStatusCode(int id, int statusCode);
    }
}
