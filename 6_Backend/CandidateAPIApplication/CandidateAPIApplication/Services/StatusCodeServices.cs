﻿using CandidateAPIApplication.Contacts;
using CandidateAPIApplication.Data;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Services
{
    public class StatusCodeServices : IStatusCodeServices
    {
        public readonly CandidatesContext _contextCandidate;

        public StatusCodeServices(CandidatesContext contextCandidate)
        {
            _contextCandidate = contextCandidate;
        }

        public async Task DeleteStatusCode(int id)
        {
            try
            {
                var findData = await _contextCandidate.StatusCandidatesProfiles.FindAsync(id);
                _contextCandidate.StatusCandidatesProfiles.Remove(findData);
                _contextCandidate.SaveChanges();
            }catch (Exception ex)
            {

            }
        }

        public async Task<List<CandidatesModel>> GetAllCandidateHasStatusByID(int id)
        {
            var items = await (
                from statuscode in _contextCandidate.StatusCandidatesProfiles
                join candidate in _contextCandidate.CandidatesProfiles on statuscode.StatusCodeID equals candidate.StatusCodeID
                where (statuscode.StatusCodeID == id )
                select new CandidatesModel
                {
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    PhoneNumber = candidate.PhoneNumber,
                    StatusCodeID = statuscode.StatusCodeID,
                }).ToListAsync();
            return items;
        }

        public async Task<List<StatusModel>> GetStatusAll()
        {
            return await _contextCandidate.StatusCandidatesProfiles.ToListAsync();
        }

        public async Task<StatusModel> GetStatusByID(int id)
        {
            var findData = await _contextCandidate.StatusCandidatesProfiles.FirstAsync(i=>i.StatusCodeID == id);
            if (findData != null)
            {
                return findData;
            }
            return null;
        }

        public async Task PostStatusCode(StatusModel dataStatus)
        {
            try
            {
                await _contextCandidate.StatusCandidatesProfiles.AddAsync(dataStatus);
                _contextCandidate.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task UpdateStatusCode(int id, string statusDescription)
        {
            try
            {
                var findData = await _contextCandidate.StatusCandidatesProfiles.FindAsync(id);
                findData.StatusDescription = statusDescription;
                await _contextCandidate.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
