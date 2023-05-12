using System;
using Candidate.Contracts;
using Candidate.Data;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Services
{
    public interface ICandidateService
    {
        List<TotalContract> GetTotal();
        List<DashboardContract> GetDashboard();
        List<EditScore> GetEditScore(Guid id);
        List<AppliedContract> GetApplied();
        List<AcceptContract> GetAccept();
        List<InterviewContract> GetInterview();
        List<InterviewContract> GetSortInterview();
        List<DisqualifiedContract> GetDisqualified();
        List<HiredContract> GetHired();
        Task<EditContract> UpdateCandidate(EditContract contract);
        Task<CreateContract> CreateUser(CUContract contract);
        Task<UserAccount> DeleteUser(Guid account);
    }
}

