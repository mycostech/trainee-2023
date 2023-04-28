using System;
using serverCandidate.Contract;
using static serverCandidate.Data.CandidateContext;

namespace serverCandidate.Services.Interfaces
{
	public interface ICandidateService
	{
		Task<List<Candidate>> GetCandidate();
		Task<Candidate> GetCandidateByID(int id);
        Task<Candidate> AddCandidate(Candidate contract, int id);
		Task<Candidate> UpdateCandidate(int id, CandidateUpdatePayload contract);
        Task<Candidate> DeleteCandidate(int id);

    }
}

