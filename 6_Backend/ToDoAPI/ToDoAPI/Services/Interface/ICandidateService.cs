using System.Threading.Tasks;
using ToDoAPI.Data;

namespace ToDoAPI.Services.Interface
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetAllCandidate();
        Task<Candidate> GetCandidates(int CandidateId);

        Task<Candidate> UpdateCandidate(int CandidateId, Candidate candidate);
        Task<Candidate> CreateCandidate(Candidate candidate);
        Task<Candidate> DeleteCandidate(int CandidateId);
        Task<List<Candidate>> GetCandidatesByStatusId(int statusId);
        Task<List<Evaluation>> GetEvaluationsByCandidateId(int candidateId);
    }
}
