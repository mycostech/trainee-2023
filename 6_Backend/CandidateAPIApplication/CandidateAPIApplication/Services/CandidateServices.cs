using CandidateAPIApplication.Contacts;
using CandidateAPIApplication.Data;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CandidateAPIApplication.Services
{
    public class CandidateServices : ICandidateServices
    {
        public readonly CandidatesContext _contextCandidate;
        public readonly IConfiguration _configuration;

        public CandidateServices(CandidatesContext contextCandidate, IConfiguration configs)
        {
            _contextCandidate = contextCandidate;
            _configuration = configs;
        }

        public async Task CreateCandidate(CandidatesModel dataCandidate)
        {
            try
            {
                _contextCandidate.CandidatesProfile.Add(dataCandidate);
                await _contextCandidate.SaveChangesAsync();
            }catch (Exception ex)
            {
               
            }
        }

        public async Task DeleteCandidateByID(int id)
        {
            try
            {
                var findata = await _contextCandidate.CandidatesProfile.FindAsync(id);
                _contextCandidate.CandidatesProfile.Remove(findata);
                await _contextCandidate.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CandidatesModel>> GetAllCandidate()
        {
            return await _contextCandidate.CandidatesProfile.ToListAsync();
        }

        public async Task<CandidatesModel> GetCandidatesByID(int id)
        {
            var findData = await _contextCandidate.CandidatesProfile.FirstOrDefaultAsync(x => x.CandidateId == id);
            if (findData != null)
            {
                return new CandidatesModel() 
                {
                    FirstName = findData.FirstName,
                    LastName = findData.LastName,
                    Email = findData.Email,
                    PhoneNumber = findData.PhoneNumber,
                };
            }
            return null;
        }

        public JwtSecurityToken GetToken(List<Claim> authClaim)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires:DateTime.Now.AddMinutes(30),
                    claims:authClaim,
                    signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256Signature)
                );
            return token;
        }

        public async Task<LoginResponse> Login(string firstName, string lastName, string email)
        {
            var findData = await _contextCandidate.CandidatesProfile
                .FirstOrDefaultAsync(i => i.FirstName == firstName && i.Email == email);
            if (findData != null && findData.LastName == lastName)
            {
                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, firstName + " " + lastName),
                    new Claim(ClaimTypes.Role, "standard"),
                    new Claim(ClaimTypes.Role, "admin")
                };

                var  token = GetToken(authClaim);
                return new LoginResponse
                {
                    Username = firstName + " " + lastName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            throw new Exception("Username or Email invalid.");
        }

        public async Task Register(RegisterContact dataRegister)
        {
            //var findData = await _contextCandidate.CandidatesProfile.FirstOrDefaultAsync(i=>i.Email == dataRegister.Email);
            if (await _contextCandidate.CandidatesProfile.AnyAsync(u=>u.Email == dataRegister.Email))
            {
                throw new Exception("Username are duplicated.");
            }

            //var newRegister = new RegisterContact
            //{
            //    FirstName = dataRegister.FirstName,
            //    LastName = dataRegister.LastName,
            //    Email = dataRegister.Email,
            //    Phone = dataRegister.Phone,
            //};

            var newCandidate = new CandidatesModel
            {
                FirstName = dataRegister.FirstName,
                LastName = dataRegister.LastName,
                Email = dataRegister.Email,
                PhoneNumber = dataRegister.Phone,
                StatusCodeID = 1,
            };

            _contextCandidate.CandidatesProfile.Add(newCandidate);
            await _contextCandidate.SaveChangesAsync();
        }

        public async Task UpdateCandidate(int id, CandidatesModel dataCandidate)
        {
            try
            {
                var findData = await _contextCandidate.CandidatesProfile.FirstOrDefaultAsync(i => i.CandidateId == id);
                findData.FirstName = dataCandidate.FirstName;
                findData.LastName = dataCandidate.LastName;
                findData.PhoneNumber = dataCandidate.PhoneNumber;
                findData.Email = dataCandidate.Email;
                findData.StatusCodeID = dataCandidate.StatusCodeID;

                await _contextCandidate.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
