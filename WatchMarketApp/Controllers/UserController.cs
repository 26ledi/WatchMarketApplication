using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchMarket.BusinessLogic.Dto_s;
using WatchMarket.BusinessLogic.Interfaces;

namespace WatchMarketApp.Controllers
{
    [ApiController]
    [Route("watchmarket")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userModel)
        {
            var user = await _userService.CreateUserAsync(userModel);

            return Ok(user);
        }

        [HttpPut("user")]
        public async Task<IActionResult> Update([FromBody] UserDto userModel)
        {
            var user = await _userService.UpdateUserAsync(userModel);

            return Ok(user);
        }

        [HttpDelete("user")]
        public async Task<IActionResult> Delete(string email)
        {
            await _userService.DeleteUserAsync(email);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] UserDto userModel)
        {
            var token = await _userService.LoginAsync(userModel);

            return Ok(new { Token = token });
        }

        //[HttpGet("logout")]
        //public IActionResult LogOut()
        //{

        //    Response.Cookies.Delete("token");

        //    return Ok(new { Message = "User succesfully logged out" });
        //}
    }
}
