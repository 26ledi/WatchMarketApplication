using Microsoft.AspNetCore.Mvc;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;

namespace WatchMarketApp.Controllers
{
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet("prices")]
        public async Task<IActionResult> GetAll()
        {
            var prices = await _priceService.GetAllAsync();

            return Ok(prices);
        }

        [HttpPost("price")]
        public async Task<IActionResult> Add([FromBody] PriceDto priceModel)
        {
            var price = await _priceService.CreateAsync(priceModel);

            return Ok(price);
        }

        [HttpPut("price")]
        public async Task<IActionResult> Update([FromBody] PriceDto priceModel)
        {
            var price = await _priceService.UpdateAsync(priceModel);

            return Ok(price);
        }

        [HttpDelete("price")]
        public async Task<IActionResult> Delete(int id)
        {
            await _priceService.DeleteAsync(id);

            return NoContent();
        }
    }
}
