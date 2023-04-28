using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Services
{
    public class ScoreService : IScoreService
    {
        private readonly CandidateContext _context;

        public ScoreService(CandidateContext context)
        {
            _context = context;
        }
        

        public async Task<List<Evaluation>> GetEvaluationByCandidateId(int candidateId)
        {
            return await _context.Evaluation.Where(e => e.CandidateId == candidateId).ToListAsync();
        }

        public async Task<Evaluation> UpdateScore(int candidateId, int scoreType, int score)
        {
            var evaluation = await _context.Evaluation.FirstOrDefaultAsync(e => e.CandidateId == candidateId);
            if (evaluation == null)
            {
                throw new Exception("Evaluation not found for candidate and score type");
            }
            evaluation.ScoreType = scoreType;
            evaluation.Score = score;
            await _context.SaveChangesAsync();

            return evaluation;
        }

        public async Task<Evaluation> InsertScore(int candidateId, int score, string scoreTypeDescription)
        {
            // Get the most recent evaluation for the candidate
            var mostRecentEvaluation = await _context.Evaluation
                .Where(e => e.CandidateId == candidateId)
                .OrderByDescending(e => e.EvaluationId)
                .FirstOrDefaultAsync();

            // Determine the score type based on the most recent evaluation
            int scoreType = 1;
            if (mostRecentEvaluation != null)
            {
                scoreType = mostRecentEvaluation.ScoreType + 1;
            }

            // Create a new evaluation object
            var newEvaluation = new Evaluation
            {
                CandidateId = candidateId,
                ScoreType = scoreType,
                Score = score,
                ScoreTypeDescription = scoreTypeDescription
            };

            // Add the new evaluation to the context and save changes
            _context.Evaluation.Add(newEvaluation);
            await _context.SaveChangesAsync();

            return newEvaluation;
        }


    }
}

