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

        [HttpGet("users")]
        public async Task<IActionResult> GetAll() 
        {
            var users = await _userService.GetAllUsersAsync(); 

            return Ok(users);
        }

        [HttpPost("user")]
        public async Task<IActionResult> Add([FromBody]UserDto userModel)
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
    }
}
