﻿using System.ComponentModel.DataAnnotations;

namespace Candidate.Data
{
    public class Appointment
    {
        public DateTime? Meet { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public User? UserAppointment { get; set; }
    }
}