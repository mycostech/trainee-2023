using System;
using System.Diagnostics.Contracts;
using Candidate.Contracts;
using Candidate.Data;
using Candidate.Services;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Services
{
	public class TodoService : ITodoService
	{
        private readonly TodoItemsContext _context;
        public TodoService(TodoItemsContext context)
		{
            _context = context;
        }

        public List<UserContract> GetUser()
        {
            List<User> result = _context.Users.Include(a=>a.OwnedFile).ToList();
            var list = result.Select(u =>
            {
                return new UserContract()
                {
                    DateCreated = DateTime.Now,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Description = u.Description ?? string.Empty,
                    UrlFile = u.OwnedFile != null ? new UrlFileContract
                    {
                        File = u.OwnedFile.File,
                        UserId = u.OwnedFile.UserId
                    } : null

                };
            });
            return list.ToList();
        }
        public async Task<UserContract> CreateUser(UserContract contract)
        {
            var user = new User
            { 
                DateCreated = DateTime.Now,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname ?? string.Empty,
                Position = contract.Position ?? string.Empty,
                Description = contract.Description ?? string.Empty,
                OwnedFile = new UrlFile { File = null}
            };
            //user.OwnedFile = new UrlFile { UserId = user.Id, File = "sdefrtgyhujksdfgh" };
            _context.Users.Add(user);
            //_context.UrlFiles.Add(user);
            await _context.SaveChangesAsync();
            return new UserContract()
            {
                DateCreated = DateTime.Now,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname ?? string.Empty,
                Position = contract.Position ?? string.Empty,
                Description = contract.Description ?? string.Empty,
            };

        }
    }
}






