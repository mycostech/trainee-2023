using System;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using serverCandidate.Contract;
using serverCandidate.Data;
using serverCandidate.Services.Interfaces;
using static serverCandidate.Data.CandidateContext;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace serverCandidate.Services
{
	public class RecruiterService : IRecruiterService
    {
        private readonly CandidateContext _context;
        private readonly IConfiguration _config;

        public RecruiterService(CandidateContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<List<Recruiter>> GetRecruiter()
        {
            return await _context.Recruiters.ToListAsync();
        }
        public async Task<Recruiter> GetRecruiterByID (int id)
        {
            return await _context.Recruiters.FirstOrDefaultAsync(r => r.idRecruiter == id);
        }
        public async Task<Recruiter> AddRecruiter(Recruiter contract)
        {
            DateTime currentDateTime = DateTime.Now;
            var recruiter = new Recruiter()
            {
                firstName = contract.firstName,
                lastName = contract.lastName,
                email = contract.email,
                position = contract.position,
                imageProfile = contract.imageProfile,
                createAt = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
            try
            {
                _context.Recruiters.Add(recruiter);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return contract;

        }
        public async Task<Recruiter> UpdateRecruiter(int id, RecruiterUpdatePayload contract)
        {
            DateTime currentDateTime = DateTime.Now;
            var recruiter = _context.Recruiters.First(r => r.idRecruiter == id);
            recruiter.idRecruiter = id;
            recruiter.firstName = contract.firstName ?? recruiter.firstName;
            recruiter.lastName = contract.lastName ?? recruiter.lastName;
            recruiter.email = contract.email ?? recruiter.email;
            recruiter.position = contract.position ?? recruiter.position;
            recruiter.imageProfile = contract.imageProfile ?? recruiter.imageProfile;
            recruiter.updateAt = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                await _context.SaveChangesAsync();
                return recruiter;
            }
            catch(DbUpdateConcurrencyException err)
            {
                throw new Exception(err.Message);
            }
        }
        public async Task<Recruiter> DeleteRecruiter(int id)
        {
            try
            {
                var recruiter = _context.Recruiters.First(r => r.idRecruiter == id);
                _context.Recruiters.Remove(recruiter);
                await _context.SaveChangesAsync();
                return recruiter;
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<string> Register(RegisterContract model)
        {
            if (_context.Recruiters.Any(u => u.username == model.username))
                throw new Exception("Username is duplicated");

            DateTime currentDateTime = DateTime.Now;
            var recruiter = new Recruiter()
            {
                username = model.username,
                password = model.password,

                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                position = model.position,
                imageProfile = model.imageProfile,
                createAt = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
            _context.Recruiters.Add(recruiter);
            int result = await _context.SaveChangesAsync();
            if(result == 1)
            {
                return "Success";
            }
            else
            {
                throw new Exception("Failed to create recuiter");
            }
        }

        public async Task<LoginResponse> Login(string username, string password)
        {
            var recruiter = await _context.Recruiters.FirstOrDefaultAsync(a => a.username == username);
            if (recruiter == null || recruiter.password != password)
            {
                throw new Exception("Invaild login!");
            }
            else
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, recruiter.username),
                    new Claim(ClaimTypes.Sid, recruiter.idRecruiter.ToString()),
                    new Claim(ClaimTypes.Role, "standard"),
                    new Claim(ClaimTypes.Role, "admin"),
                };
                var token = GetToken(authClaims);
                Console.WriteLine("Success Login! ({0})", recruiter.username);

                return new LoginResponse
                {
                    username = username,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            throw new Exception("Username or password is invaild");
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return token;
        }
    }
}

