using System;
using System.ComponentModel.DataAnnotations;
using Candidate.Data;

namespace Candidate.Contracts
{
    public class CreateContract
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; }
        public UrlFileContract? UrlFile { get; set; }
        public ScoreContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        public AppointmentContract? Appointment { get; set; }
    }

    public class DashboardContract
    {
        public int Candidates { get; set; }
        public int Applied { get; set; }
        public int Accept { get; set; }
        public int Interview { get; set; }
        public int Disqualifified { get; set; }
        public int Hired { get; set; }
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        //public string? Description { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; } 
        public DateTime DateCreated { get; set; } 
        //public UrlFileContract? UrlFile { get; set; }
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        //public AppointmentContract? Appointment { get; set; }
    }

    public class UserAccount
    {
        public Guid Id { get; set; }
    }

    public class AppliedContract
    {
        public int Applied { get; set; }
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; } 
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
    }

    public class AcceptContract
    {
        public int Accept { get; set; }
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; } 
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
    }

    public class InterviewContract
    {
        public int Interview { get; set; }
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        public AppointmentContract? Appointment { get; set; }
    }

    public class DisqualifiedContract
    {
        public int Disqualified { get; set; }
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        public AppointmentContract? Appointment { get; set; }
    }

    public class HiredContract
    {
        public int Hired { get; set; }
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; } 
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
    }
}

