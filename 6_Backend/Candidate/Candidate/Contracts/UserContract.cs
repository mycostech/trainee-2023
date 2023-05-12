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

    public class CUContract
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Image { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
    }

    public class DashboardContract
    {
        //public int Candidat es { get; set; }
        //public int Applied { get; set; }
        //public int Accept { get; set; }
        //public int Interview { get; set; }
        //public int Disqualifified { get; set; }
        //public int Hired { get; set; }
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
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; }
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        public AppointmentContract? Appointment { get; set; }
    }

    public class DisqualifiedContract
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; }
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
        //public AppointmentContract? Appointment { get; set; }
    }

    public class HiredContract
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public int? Status { get; set; }
        public DateTime DateCreated { get; set; } 
        public EvaluatioContract? Score { get; set; }
        public PictureContract? Picture { get; set; }
    }

    public class TotalContract
    {
        public int Candidates { get; set; }
        public int Applied { get; set; }
        public int Accept { get; set; }
        public int Interview { get; set; }
        public int Disqualifified { get; set; }
        public int Hired { get; set; }
    }

}

