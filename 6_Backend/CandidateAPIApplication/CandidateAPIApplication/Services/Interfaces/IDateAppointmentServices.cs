using CandidateAPIApplication.Models;

namespace CandidateAPIApplication.Services.Interfaces
{
    public interface IDateAppointmentServices
    {
        public Task<List<DateAppointmentsModel>> GetAllDateAppointment();
        public Task<DateAppointmentsModel> GetDateAppointmentById(int id);
        public Task UpdateDateAppointment(int id, DateAppointmentsModel dataDateAppointment);
        public Task DeleteDateAppointmentById(int id);
        public Task CreateDateAppointment(DateAppointmentsModel dataDateAppointment);
        public Task<DateAppointmentsModel> GetDateAppointmentsByCandidateId(int candidateId);
    }
}
