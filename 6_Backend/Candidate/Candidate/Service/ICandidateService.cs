using System;
using Candidate.Contracts;
using Candidate.Data;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Services
{
    public interface ICandidateService
    {
        List<DashboardContract> GetDashboard();
        List<AppliedContract> GetApplied();
        List<AcceptContract> GetAccept();
        List<InterviewContract> GetInterview();
        List<DisqualifiedContract> GetDisqualified();
        List<HiredContract> GetHired();
        Task<EditContract> UpdateCandidate(EditContract contract, Guid id);
        Task<CreateContract> CreateUser(CreateContract contract);
        Task<UserAccount> DeleteUser(UserAccount account);
    }
}

