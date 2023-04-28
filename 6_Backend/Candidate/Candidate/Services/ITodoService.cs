using System;
using Candidate.Contracts;
using Candidate.Data;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Services
{
	public interface ITodoService
	{
        List<UserContract> GetUser();
        Task<UserContract> CreateUser(UserContract contract);
    }

}

