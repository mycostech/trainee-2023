using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.Services;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            try
            {
                await _userService.Register(model);
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
