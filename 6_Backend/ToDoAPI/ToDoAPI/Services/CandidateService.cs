using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Services
{
    public class CandidateService :ICandidateService
    {
        private readonly CandidateContext _context;
        public CandidateService(CandidateContext context)
        {
            _context = context;
        }
        public async Task<List<Candidate>> GetAllCandidate()
        {
            return await _context.Candidate.ToListAsync();
        }
        public async Task<Candidate> GetCandidates(int CandidateId)
        {
            var todoItems = await _context.Candidate.FirstOrDefaultAsync(c => c.CandidateId == CandidateId);
            try
            {
                return todoItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Candidate> UpdateCandidate(int CandidateId, Candidate candidate)
        {
            try
            {
                var todo = _context.Candidate.First(a => a.CandidateId == CandidateId);
                todo.Name = candidate.Name;
                todo.StatusID = candidate.StatusID;
                todo.PhoneNumber = candidate.PhoneNumber;
                todo.Email = candidate.Email;
                todo.InterviewDate = candidate.InterviewDate;
                todo.Score = candidate.Score;
                todo.ResumeFilePath = candidate.ResumeFilePath;
                todo.ProfilePicPath = candidate.ProfilePicPath;
                todo.CVPath = candidate.CVPath;

                await _context.SaveChangesAsync();

                return todo;
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                throw new Exception(ex.Message);

            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}"); ;
            }
            
        }
        public async Task<Candidate> CreateCandidate(Candidate candidate)
        {
            try
            {

                _context.Candidate.Add(candidate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}"); ;
            }
            return candidate;
        }
        public async Task<Candidate> DeleteCandidate(int CandidateId)
        {
            try
            {
                var todel = _context.Candidate.Find(CandidateId);
                _context.Candidate.Remove(todel);
                await _context.SaveChangesAsync();
                return new Candidate()
                {
                    CandidateId = todel.CandidateId,
                };
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}"); ;
            }
        
        }
        public async Task<List<Candidate>> GetCandidatesByStatusId(int statusId)
        {
            try
            {
                return await _context.Candidate.Where(c => c.StatusID == statusId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<Evaluation>> GetEvaluationsByCandidateId(int candidateId)
        {
            try
            {
                return await _context.Evaluation.Where(e => e.CandidateId == candidateId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

    }

    //#SELECT * From Evaluation RIGHT JOIN Candidate ON Evaluation.CandidateId =Candidate.CandidateId WHERE Evaluation.CandidateId =1
}
