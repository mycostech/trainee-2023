using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serverCandidate.Contract;
using serverCandidate.Data;
using serverCandidate.Services.Interfaces;
using static serverCandidate.Data.CandidateContext;

namespace serverCandidate.Services
{
	public class CandidateService : ControllerBase, ICandidateService
    {
        private readonly CandidateContext _context;
        public CandidateService(CandidateContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetCandidate()
        {
            return await _context.Candidates.ToListAsync();
        }
        public async Task<Candidate> GetCandidateByID(int id)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.idCandidate == id);
        }
        public async Task<Candidate> AddCandidate(Candidate contract, int id)
        {
            DateTime currentDateTime = DateTime.Now;
            //var id = HttpContext?.User?.FindFirst(ClaimTypes.Sid);
            var candidate = new Candidate()
            {
                firstName = contract.firstName,
                lastName = contract.lastName,
                email = contract.email,
                position = contract.position,
                status = contract.status,
                skills = contract.skills,
                imageProfile = contract.imageProfile,
                resume = contract.resume,
                CV = contract.CV,
                rating = contract.rating,
                createAt = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                idRecruiter = id
            };
            try
            {
                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return contract;
        }
        public async Task<Candidate> UpdateCandidate(int id, CandidateUpdatePayload contract)
        {
            DateTime currentDateTime = DateTime.Now;
            var candidate = _context.Candidates.First(c => c.idCandidate == id);
            candidate.idCandidate = id;
            candidate.firstName = contract.firstName ?? candidate.firstName;
            candidate.lastName = contract.lastName ?? candidate.lastName;
            candidate.email = contract.email ?? candidate.email;
            candidate.skills = contract.skills ?? candidate.skills;
            candidate.position = contract.position ?? candidate.position;
            candidate.imageProfile = contract.imageProfile ?? candidate.imageProfile;
            candidate.resume = contract?.resume ?? candidate.resume;
            candidate.CV = contract?.CV ?? candidate.CV;
            candidate.updateAt = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                await _context.SaveChangesAsync();
                return candidate;
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw new Exception(err.Message);
            }
        }
        public async Task<Candidate> DeleteCandidate(int id)
        {
            try
            {
                var candidate = _context.Candidates.First(r => r.idCandidate == id);
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
                return candidate;
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}

