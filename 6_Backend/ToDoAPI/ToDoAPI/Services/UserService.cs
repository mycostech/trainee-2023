using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Services
{
    public class UserService : IUserServices
    {
        private readonly CandidateContext _context;
        private readonly IConfiguration _configuration;
        public UserService(CandidateContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
           
        }
        public async Task<User> CreateUser(User model)
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
            return user;
        }
        public async Task<LoginResponse> Login(string username, string password) 
        { 
            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserName == username );
            if (user != default && user.Password == password)
            {
                var authClaims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "standard"),
                    new Claim(ClaimTypes.Role, "admin"),
                };
                var token = GetToken(authClaims);

                return new LoginResponse
                {
                    UserName = username,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpDate = token.ValidTo
                };
            }
            throw new Exception("Username or password is invaild");
        
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAuduence"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return token;
        }
    }
}
