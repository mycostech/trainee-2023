﻿using CandidateAPIApplication.Data;
using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPIApplication.Services
{
    public class DateAppointmentServices : IDateAppointmentServices
    {
        public readonly CandidatesContext _contextDateAppoint;

        public DateAppointmentServices(CandidatesContext contextDateAppoint)
        {
            _contextDateAppoint = contextDateAppoint;
        }
        public async Task CreateDateAppointment(DateAppointmentsModel dataDateAppointment)
        {
            try
            {
                await _contextDateAppoint.DateAppointmentProfiles.AddAsync(dataDateAppointment);
                _contextDateAppoint.SaveChanges();
            }catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDateAppointmentById(int id)
        {
            try
            {
                var findData = await _contextDateAppoint.DateAppointmentProfiles.FirstOrDefaultAsync(i => i.AppointmentID == id);
                _contextDateAppoint.DateAppointmentProfiles.Remove(findData);
                _contextDateAppoint.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DateAppointmentsModel>> GetAllDateAppointment()
        {
            return await _contextDateAppoint.DateAppointmentProfiles.ToListAsync();
        }

        public async Task<DateAppointmentsModel> GetDateAppointmentById(int id)
        {
            try
            {
                var findData = await _contextDateAppoint.DateAppointmentProfiles.FirstOrDefaultAsync(i => i.AppointmentID == id);
                return findData;
            }catch (ArgumentException ex)
            {
                return null;
            }
        }

        public async Task<DateAppointmentsModel> GetDateAppointmentsByCandidateId(int candidateId)
        {
            return await _contextDateAppoint.DateAppointmentProfiles.FirstOrDefaultAsync(date => date.CandidateId == candidateId);
        }

        public async Task UpdateDateAppointment(int id, DateAppointmentsModel dataDateAppointment)
        {
            try
            {
                var findData = await _contextDateAppoint.DateAppointmentProfiles.FirstOrDefaultAsync(i=>i.AppointmentID == id);
                findData.StartAppointment = dataDateAppointment.StartAppointment;
                findData.EndAppointment = dataDateAppointment.EndAppointment;
                _contextDateAppoint.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
