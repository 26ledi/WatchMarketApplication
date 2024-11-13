using Microsoft.AspNetCore.Mvc;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;

namespace WatchMarketApp.Controllers
{
    [ApiController]
    [Route("watchmarket")]
    public class WatchController : ControllerBase
    {
        private readonly IWatchService _watchService;

        public WatchController(IWatchService watchService)
        {
            _watchService = watchService;
        }

        [HttpGet("watches")]
        public async Task<IActionResult> GetAll()
        {
            var watches = await _watchService.GetAllAsync();

            return Ok(watches);
        }

        [HttpPost("watch")]
        public async Task<IActionResult> Add([FromBody] WatchDto watchModel)
        {
            var watch = await _watchService.CreateAsync(watchModel);

            return Ok(watch);
        }

        [HttpPut("watch")]
        public async Task<IActionResult> Update([FromBody] WatchDto watchModel)
        {
            var watch = await _watchService.Updatesync(watchModel);

            return Ok(watch);
        }

        [HttpDelete("watch")]
        public async Task<IActionResult> Delete(int id)
        {
            await _watchService.DeleteAsync(id);

            return NoContent();
        }
    }
}
