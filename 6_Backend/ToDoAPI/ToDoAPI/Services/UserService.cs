using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoAPI.Data;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly CandidateModel _context;
        private readonly IConfiguration _config;
        public UserService(CandidateModel context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        public async Task Register(User model)
        {
            if (_context.Users.Any(u => u.UserName == model.UserName))
                throw new Exception("UserName is duplicated");

            var user = new User
            {
                Name = model.Name,
                UserName = model.UserName,
                Password = model.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<LoginResponse> Login(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.UserName == username);
            if (user != default && user.Password == password)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "standard"),
                    new Claim(ClaimTypes.Role, "admin"),
                };

                var token = GetToken(authClaims);

                return new LoginResponse
                {
                    Username = username,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            throw new Exception("Username or password is invaild");
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return token;
        }
    }
}
