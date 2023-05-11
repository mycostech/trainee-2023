﻿using CandidateAPIApplication.Contacts;
using CandidateAPIApplication.Data;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

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

        public async Task ChangeStatusCode(int id, int statusCode)
        {
            try
            {
                var findData = await _contextCandidate.CandidatesProfiles.FirstOrDefaultAsync(i => i.CandidateId == id);
                findData.StatusCodeID = statusCode;

                await _contextCandidate.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task CreateCandidate(CandidateUploadData dataCandidate)
        {
            var streamImg = dataCandidate.ImageFile.OpenReadStream();
            var taskImg = new FirebaseStorage("imageresume-357f8.appspot.com").Child("Images").Child(dataCandidate.ImageName).PutAsync(streamImg);
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            var streamResume = dataCandidate.ResumeFile.OpenReadStream();
            var taskResume = new FirebaseStorage("imageresume-357f8.appspot.com").Child("Resumes").Child(dataCandidate.ResumeName).PutAsync(streamResume);

            var downloadUrlImg = await taskImg;
            var downloadUrlResume = await taskResume;
            try
            {
                
                var newcandidate = new CandidatesModel
                {
                    CandidateId = dataCandidate.CandidateID,
                    FirstName = dataCandidate.FirstName,
                    LastName = dataCandidate.LastName,
                    Email = dataCandidate.Email,
                    PhoneNumber = dataCandidate.PhoneNumber,
                    PathImage = downloadUrlImg,
                    PathResume = downloadUrlResume,
                    StatusCodeID = 1,
                };
                _contextCandidate.CandidatesProfiles.Add(newcandidate);
                await _contextCandidate.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCandidateByID(int id)
        {
            try
            {
                var finData = await _contextCandidate.CandidatesProfiles.FindAsync(id);
                _contextCandidate.CandidatesProfiles.Remove(finData);
                await _contextCandidate.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CandidatesModel>> GetAllCandidate()
        {
            return await _contextCandidate.CandidatesProfiles.ToListAsync();
        }

        public async Task<List<CandidateAndStatusDetail>> GetAllCandidateAndStatus()
        {
            var items = await (
                from candidate in _contextCandidate.CandidatesProfiles
                join statuscode in _contextCandidate.StatusCandidatesProfiles on candidate.StatusCodeID equals statuscode.StatusCodeID
                select new CandidateAndStatusDetail
                {
                    CandidateId = candidate.CandidateId,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    Phone = candidate.PhoneNumber,
                    StatusDescription = statuscode.StatusDescription
                }).ToListAsync();
            return items;
        }

        public async Task<CandidateAndStatusDetail> GetCandidateAndStatus(int id)
        {
            var items = await (
                from candidate in _contextCandidate.CandidatesProfiles
                join statuscode in _contextCandidate.StatusCandidatesProfiles on candidate.StatusCodeID equals statuscode.StatusCodeID
                where (candidate.CandidateId == id)
                select new CandidateAndStatusDetail
                {
                    CandidateId = candidate.CandidateId,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    Phone = candidate.PhoneNumber,
                    StatusDescription = statuscode.StatusDescription
                }).FirstOrDefaultAsync();
            return items;
        }

        public async Task<CandidatesModel> GetCandidatesByID(int id)
        {
            var findData = await _contextCandidate.CandidatesProfiles.FirstOrDefaultAsync(x => x.CandidateId == id);
            if (findData != null)
            {
                return new CandidatesModel()
                {
                    CandidateId = findData.CandidateId,
                    FirstName = findData.FirstName,
                    LastName = findData.LastName,
                    Email = findData.Email,
                    PhoneNumber = findData.PhoneNumber,
                    PathImage = findData.PathImage,
                    PathResume = findData.PathResume,
                    StatusCodeID = findData.StatusCodeID,
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
                    expires: DateTime.Now.AddMinutes(30),
                    claims: authClaim,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return token;
        }

        public async Task<LoginResponse> Login(string firstName, string lastName, string email)
        {
            var findData = await _contextCandidate.CandidatesProfiles
                .FirstOrDefaultAsync(i => i.FirstName == firstName && i.Email == email);
            if (findData != null && findData.LastName == lastName)
            {
                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, firstName + " " + lastName),
                    new Claim(ClaimTypes.Role, "standard"),
                    new Claim(ClaimTypes.Role, "admin")
                };

                var token = GetToken(authClaim);
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
            if (await _contextCandidate.CandidatesProfiles.AnyAsync(u => u.Email == dataRegister.Email))
            {
                throw new Exception("Username are duplicated.");
            }

            var newCandidate = new CandidatesModel
            {
                FirstName = dataRegister.FirstName,
                LastName = dataRegister.LastName,
                Email = dataRegister.Email,
                PhoneNumber = dataRegister.Phone,
                StatusCodeID = 1,
            };

            _contextCandidate.CandidatesProfiles.Add(newCandidate);
            await _contextCandidate.SaveChangesAsync();
        }

        public async Task UpdateCandidate(int id, CandidatesModel dataCandidate)
        {
            try
            {
                var findData = await _contextCandidate.CandidatesProfiles.FirstOrDefaultAsync(i => i.CandidateId == id);
                findData.FirstName = dataCandidate.FirstName;
                findData.LastName = dataCandidate.LastName;
                findData.PhoneNumber = dataCandidate.PhoneNumber;
                findData.Email = dataCandidate.Email;
                findData.StatusCodeID = dataCandidate.StatusCodeID;
                findData.PathResume = dataCandidate.PathResume;
                findData.PathImage = dataCandidate.PathImage;
                await _contextCandidate.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}