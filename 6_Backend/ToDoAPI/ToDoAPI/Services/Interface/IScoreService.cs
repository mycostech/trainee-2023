using System.Threading.Tasks;
using ToDoAPI.Data;

namespace ToDoAPI.Services.Interface
{
    public interface IScoreService
    {
        Task<List<Evaluation>> GetEvaluationByCandidateId(int candidateId);
        Task<Evaluation> UpdateScore(int candidateId, Evaluation evaluation);

        Task<Evaluation> InsertScore(int candidateId, int score, string scoreTypeDescription);
    }
}