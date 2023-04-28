using ToDoAPI.Data;

namespace CandidateHW.Services.Interfaces
{
    public interface ICandidateServices
    {
        Task<List<Candidate>> GetAllCandidate();
        //Task<List<Candidate>> GetCandidateUserId();
        Task<Candidate> UpdateCandidate(int id, Candidate contract);
        Task<Candidate> CreateCandiate(Candidate contract);
        Task<Candidate> DeleteCandidate(int id);
    }
}
