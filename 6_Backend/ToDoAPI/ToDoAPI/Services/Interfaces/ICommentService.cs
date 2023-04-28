using ToDoAPI.Data;

namespace ToDoAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<Commentinfo>> GetCandidateCondition(int CandidateId);

        Task<Commentinfo> CreateComment(Commentinfo contract);
    }
}
