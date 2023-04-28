using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly CandidateModel _context;

        public CommentService(CandidateModel context)
        {
            _context = context;
        }
        public async Task<List<Commentinfo>> GetCandidateCondition(int CandidateId)
        {
            //return await _context.Candidate.Where(ci => ci.CandidateId == CandidateId).ToListAsync();

            var candidates = await _context.Commentinfo.Where(c => c.CandidateId == CandidateId).ToListAsync();

            return candidates;
        }

        public async Task<Commentinfo> CreateComment(Commentinfo contract)
        {
            try
            {
                _context.Commentinfo.AddRange(contract);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw new Exception("Save error");
            }
            catch (Exception err)
            {
                throw;
            }
            return contract;
        }
    }
}
