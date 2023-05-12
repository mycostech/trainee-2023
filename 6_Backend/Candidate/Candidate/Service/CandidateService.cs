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
        public List<TotalContract> GetTotal()
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
                return new TotalContract()
                {
                    Candidates = count_candidate,
                    Applied = applied,
                    Accept = accept,
                    Interview = interview,
                    Disqualifified = disqualifified,
                    Hired = hired
                };
            });
            return list.ToList();
        }
        public List<DashboardContract> GetDashboard()
        {
            List<User> result = _context.Users.Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();

            var list = result.Select(u =>
            {
                return new DashboardContract()
                {
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

        public List<AppliedContract> GetApplied()
        {
            List<User> result = _context.Users.Where(x => x.Status == 0)
                .Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();
            var list = result.Select(u =>
            {
                return new AppliedContract()
                {
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
            List<User> result = _context.Users.Where(x => x.Status == 1)
                .Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();
            var list = result.Select(u =>
            {
                return new AcceptContract()
                {
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
            List<User> result = _context.Users.Where(x => x.Status == 2).Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).Include(a => a.OwnedAppointment).ToList();
            var list = result.Select(u =>
            {
                return new InterviewContract()
                {
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

        public List<InterviewContract> GetSortInterview()
        {
            List<User> result = _context.Users.Where(x => x.Status == 2).Include(a => a.OwnedScore)
                .OrderByDescending(x => x.OwnedScore.Evaluation)
                .Include(a => a.OwnedPicture).Include(a => a.OwnedAppointment).ToList();
            var list = result.Select(u =>
            {
                return new InterviewContract()
                {
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
            List<User> result = _context.Users.Where(x => x.Status == 3).Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).Include(a => a.OwnedAppointment).ToList();
            var list = result.Select(u =>
            {
                return new DisqualifiedContract()
                {
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
                    } : null,
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

        public List<HiredContract> GetHired()
        {
            List<User> result = _context.Users.Where(x => x.Status == 4)
                .Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture).ToList();
            var list = result.Select(u =>
            {
                return new HiredContract()
                {
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

        public List<EditScore> GetEditScore(Guid id)
        {
            List<User> result = _context.Users.Where(x => x.Id == id)
                .Include(a => a.OwnedScore)
                .Include(a => a.OwnedPicture)
                .Include(a => a.OwnedAppointment)
                .Include(a => a.OwnedFile).ToList();

            var list = result.Select(u =>
            {
                return new EditScore()
                {
                    Id = u.Id,
                    DateCreated = u.DateCreated,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname ?? string.Empty,
                    Position = u.Position ?? string.Empty,
                    Status = u.Status,
                    #region Foreign key
                    Score = u.OwnedScore != null ? new ScoreContract
                    {
                        Experience = u.OwnedScore.Experience,
                        Skill = u.OwnedScore.Skill,
                        Attitude = u.OwnedScore.Attitude,
                        TeamPlayer = u.OwnedScore.TeamPlayer,
                        Personality = u.OwnedScore.Personality,
                        Comment = u.OwnedScore.Comment,
                        Evaluation = u.OwnedScore.Evaluation,
                        UserId = u.OwnedScore.UserId,
                    } : null,
                    Picture = u.OwnedPicture != null ? new PictureContract
                    {
                        Image = u.OwnedPicture.Image,
                        UserId = u.OwnedPicture.UserId
                    } : null,
                    UrlFile = u.OwnedFile != null ? new UrlFileContract
                    {
                        File = u.OwnedFile.File,
                        UserId = u.OwnedFile.UserId
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
        public async Task<EditContract> UpdateCandidate(EditContract contract)
        {
            try
            {
                var doUser = _context.Users.First(c => c.Id == contract.Id);
                doUser.Status = contract.Status;
                var doScore = _context.Scores.First(c => c.UserId == contract.Id);
                doScore.Experience = contract.Experience;
                doScore.Skill = contract.Skill;
                doScore.Attitude = contract.Attitude;
                doScore.TeamPlayer = contract.TeamPlayer;
                doScore.Personality = contract.Personality;
                doScore.Comment = contract.Comment;
                var evaluation = (float)(contract.Skill + contract.Attitude +
                    contract.TeamPlayer + contract.Personality + contract.Experience) / 5;
                doScore.Evaluation = evaluation;
                var doAppointments = _context.Appointments.First(c => c.UserId == contract.Id);
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

    

    public async Task<CreateContract> CreateUser(CUContract contract)
        {
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwrot", contract.UrlFile.File);
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
                OwnedPicture = new Picture { Image = contract.Image }, // wait for build
                OwnedAppointment = new Appointment { Meet = null } // wait for build

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new CreateContract()
            {
                Id = contract.Id,
                DateCreated = DateTime.Now,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname ?? string.Empty,
                Position = contract.Position ?? string.Empty,
                Description = contract.Description ?? string.Empty,
                Status = 0,
                UrlFile = null,
                Score = null,
                Picture = null,
                Appointment = null
            };
        }
        public async Task<UserAccount> DeleteUser(Guid account)
        {
            var todo = _context.Users.FirstOrDefault(a => a.Id == account);
            _context.Users.Remove(todo);
            await _context.SaveChangesAsync();
            return new UserAccount()
            {
                Id = account
            };
        }
    }
}






