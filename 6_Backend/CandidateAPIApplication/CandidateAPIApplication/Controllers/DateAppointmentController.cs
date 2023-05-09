using CandidateAPIApplication.Models;
using CandidateAPIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateAppointmentController : ControllerBase
    {
        public readonly IDateAppointmentServices _servicesDateAppointment;
       public DateAppointmentController(IDateAppointmentServices servicesDateAppointment)
        {
            _servicesDateAppointment = servicesDateAppointment;
        }

        [HttpGet]
        public async Task<List<DateAppointmentsModel>> GetAllDateAppointment()
        {
            return await _servicesDateAppointment.GetAllDateAppointment();
        }

        [HttpGet("{id}")]
        public async Task<DateAppointmentsModel> GetDateAppointmentById([FromRoute] int id)
        {
            return await _servicesDateAppointment.GetDateAppointmentById(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDateAppointmentById([FromRoute] int id)
        {
            await _servicesDateAppointment.DeleteDateAppointmentById(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> CreateDateAppointment([FromBody] DateAppointmentsModel dataDateAppointment)
        {
            await _servicesDateAppointment.CreateDateAppointment(dataDateAppointment);
            return Ok(dataDateAppointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDateAppointment([FromRoute] int id, [FromBody] DateAppointmentsModel dataDateAppointment)
        {
            await _servicesDateAppointment.UpdateDateAppointment(id, dataDateAppointment);
            return Ok(dataDateAppointment);
        }

        [HttpGet("Candidate/{id}")]
        public async Task<DateAppointmentsModel> GetDateAppointmentsByCandidateId([FromRoute] int id)
        {
            return await _servicesDateAppointment.GetDateAppointmentsByCandidateId(id);
        }
    }
}
