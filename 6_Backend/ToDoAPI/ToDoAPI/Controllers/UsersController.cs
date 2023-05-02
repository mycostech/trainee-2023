using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UsersController(IUserServices userServices)
        {
            _userService = userServices;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser([FromBody] User model)
        {
            try
            {
                await _userService.CreateUser(model);
                //await _hub.Clients.All.SendAsync("register", model);
                return Ok("User created successfully!");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);

            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var userToken = await _userService.Login(username, password);
                //await _hub.Clients.All.SendAsync("login", new { username, password });
                return Ok(userToken);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
        }
    }
}
