using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.NetworkInformation;
using Candidate.Contracts;
using Candidate.Data;
using Candidate.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Candidate.Services
{
	public class CandidateService : ICandidateService
	{
        private readonly TodoItemsContext _context;
        public CandidateService(TodoItemsContext context)
		{
            _context = context;
        }

        public List<DashboardContract> GetDashboard()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();

            var candidate = _context.Users.Select(x => x);
            int count_candidate = candidate.Count();
            var applied = _context.Users.Where(x => x.Status == 0).Count();
            var accept = _context.Users.Where(x => x.Status == 1).Count();
            var interview = _context.Users.Where(x => x.Status == 2).Count();
            var disqualifified = _context.Users.Where(x => x.Status == 3).Count();
            var hired = _context.Users.Where(x => x.Status == 4).Count();
            var list = result.Select(u =>
            {
                return new DashboardContract()
                {
                    Candidates = count_candidate,
                    Applied = applied,
                    Accept = accept,
                    Interview = interview,
                    Disqualifified = disqualifified,
                    Hired = hired,
                    Id = u.Id,
                    DateCreated = u.DateCreated,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    //Description = u.Description ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    //UrlFile = u.OwnedFile != null ? new UrlFileContract
                    //{
                    //    File = u.OwnedFile.File,
                    //    UserId = u.OwnedFile.UserId
                    //} : null,
                    Score = u.OwnedScore != null ? new EvaluatioContract
                    {
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null
                    //Appointment = u.OwnedAppointment != null ? new AppointmentContract
                    //{
                    //    Meet = u.OwnedAppointment.Meet,
                    //    UserId = u.OwnedAppointment.UserId
                    //} : null
                    #endregion
                };
            });
            return list.ToList();
        }

        public List<AppliedContract> GetApplied()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();
            var applied = _context.Users.Where(x => x.Status == 0).Count();
            var list = result.Select(u =>
            {
                return new AppliedContract()
                {
                    Applied = applied,
                    Id = u.Id,
                    DateCreated = u.DateCreated,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    Score = u.OwnedScore != null ? new EvaluatioContract
                    {
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null
                    #endregion
                };
            });
            return list.ToList();
        }

        public List<AcceptContract> GetAccept()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();
            var accept = _context.Users.Where(x => x.Status == 1).Count();
            var list = result.Select(u =>
            {
                return new AcceptContract()
                {
                    Accept = accept,
                    Id = u.Id,
                    DateCreated = u.DateCreated,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    Score = u.OwnedScore != null ? new EvaluatioContract
                    {
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null
                    #endregion
                };
            });
            return list.ToList();
        }

        public List<InterviewContract> GetInterview()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).Include(a => a.OwnedAppointment).ToList();
            var interview = _context.Users.Where(x => x.Status == 2).Count();
            var list = result.Select(u =>
            {
                return new InterviewContract()
                {
                    Interview = interview,
                    Id = u.Id,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    Score = u.OwnedScore != null ? new EvaluatioContract
                    {
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null,
                    Appointment = u.OwnedAppointment != null ? new AppointmentContract
                    {
                        Meet = u.OwnedAppointment.Meet,
                        UserId = u.OwnedAppointment.UserId
                    } : null
                    #endregion
                };
            });
            return list.ToList();
        }

        public List<DisqualifiedContract> GetDisqualified()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).Include(a => a.OwnedAppointment).ToList();
            var disqualifified = _context.Users.Where(x => x.Status == 3).Count();
            var list = result.Select(u =>
            {
                return new DisqualifiedContract()
                {
                    Disqualified = disqualifified,
                    Id = u.Id,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    Score = u.OwnedScore != null ? new EvaluatioContract
                    {
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null,
                    Appointment = u.OwnedAppointment != null ? new AppointmentContract
                    {
                        Meet = u.OwnedAppointment.Meet,
                        UserId = u.OwnedAppointment.UserId
                    } : null
                    #endregion
                };
            });
            return list.ToList();
        }

        public List<HiredContract> GetHired()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();
            var hired = _context.Users.Where(x => x.Status == 4).Count();
            var list = result.Select(u =>
            {
                return new HiredContract()
                {
                    Hired = hired,
                    Id = u.Id,
                    DateCreated = u.DateCreated,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    Score = u.OwnedScore != null ? new EvaluatioContract
                    {
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null
                    #endregion
                };
            });
            return list.ToList();
        }

        public async Task<EditContract> UpdateCandidate(EditContract contract, Guid id)
        {
            try
            {
                var doUser = _context.Users.First(c => c.Id == id);
                doUser.Status = contract.Status;
                var doScore = _context.Scores.First(c => c.UserId == id);
                doScore.Experience = contract.Experience;
                doScore.Skill = contract.Skill;
                doScore.Attitude = contract.Attitude;
                doScore.TeamPlayer = contract.TeamPlayer;
                doScore.Personality = contract.Personality;
                doScore.Comment = contract.Comment;
                var evaluation = (float)(contract.Skill + contract.Attitude +
                    contract.TeamPlayer + contract.Personality) / 5;
                doScore.Evaluation = evaluation;
                var doAppointments = _context.Appointments.First(c => c.UserId == id);
                doAppointments.Meet = contract.Meet;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw new Exception("Save error");
            }
            catch (Exception err)
            {
                throw;
            }
            return contract;
        }

    

    public async Task<CreateContract> CreateUser(CreateContract contract)
        {
            var user = new User
            { 
                DateCreated = DateTime.Now,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname ?? string.Empty,
                Position = contract.Position ?? string.Empty,
                Description = contract.Description ?? string.Empty,
                Status = 0,
                OwnedFile = new UrlFile { File = null },  // wait for build
                OwnedScore = new Score
                {
                    Experience = 0,
                    Skill = 0,
                    Attitude = 0,
                    TeamPlayer = 0,
                    Personality = 0,
                    Comment = string.Empty,
                    Evaluation = 0
                },
                OwnedPicture = new Picture { Image = null }, // wait for build
                OwnedAppointment = new Appointment { Meet = null } // wait for build

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new CreateContract()
            {
                Id = contract.Id,
                DateCreated = contract.DateCreated,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname ?? string.Empty,
                Position = contract.Position ?? string.Empty,
                Description = contract.Description ?? string.Empty,
                Status = contract.Status,
                UrlFile = null,
                Score = null,
                Picture = null,
                Appointment = null
            };
        }
        public async Task<UserAccount> DeleteUser(UserAccount account)
        {
            var todo = _context.Users.FirstOrDefault(a => a.Id == account.Id);
            _context.Users.Remove(todo);
            await _context.SaveChangesAsync();
            return new UserAccount()
            {
                Id = account.Id
            };
        }
    }
}






