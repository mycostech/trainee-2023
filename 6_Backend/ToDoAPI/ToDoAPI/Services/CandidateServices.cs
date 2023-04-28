using CandidateHW.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;

namespace CandidateHW.Services
{
    public class CandidateServices : ICandidateServices
    {
        private readonly CandidateModel _context;
        public CandidateServices(CandidateModel context)
        {
            _context = context;
        }

        public async Task<Candidate> CreateCandiate(Candidate contract)
        {
            try
            {
                _context.Candidate.AddRange(contract);
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

        public async Task<Candidate> DeleteCandidate(int id)
        {
            var todo = _context.Candidate.Find(id);
            try
            {
                _context.Candidate.Remove(todo);
                await _context.SaveChangesAsync();
                return new Candidate()
                {
                    CandidateId = todo.CandidateId,
                    FirstName = todo.FirstName

                };
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw new Exception("Save error");
            }
            catch (Exception err)
            {
                throw;
            }
        }

        public async Task<List<Candidate>> GetAllCandidate()
        {
            return await _context.Candidate.ToListAsync();
        }

        //public async Task<List<Candidate>> GetCandidateUserId()
        //{
        //    return await _context.Candidate.ToListAsync();
        //}

        public async Task<Candidate> UpdateCandidate(int id, Candidate contract)
        {
            try
            {
                var todo = _context.Candidate.First(c => c.CandidateId == id);
                todo.CandidateId = id;
                todo.FirstName = contract.FirstName;
                todo.LastName = contract.LastName;
                todo.PhoneNumber = contract.PhoneNumber;
                todo.Email = contract.Email;

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
