using System;
using serverCandidate.Contract;
using static serverCandidate.Data.CandidateContext;

namespace serverCandidate.Services.Interfaces
{
	public interface IRecruiterService
	{
        Task<List<Recruiter>> GetRecruiter();
        Task<Recruiter> GetRecruiterByID(int id);
        Task<Recruiter> AddRecruiter(Recruiter contract);
        Task<Recruiter> UpdateRecruiter(int id, RecruiterUpdatePayload contract);
        Task<Recruiter> DeleteRecruiter(int id);
        Task<string> Register(RegisterContract model);
        Task<LoginResponse> Login(string username, string password);
    }
}



