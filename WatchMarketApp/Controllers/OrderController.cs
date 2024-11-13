using Microsoft.AspNetCore.Mvc;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;

namespace WatchMarketApp.Controllers
{
    [ApiController]
    [Route("watchmarket")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();

            return Ok(orders);
        }

        [HttpPost("orders")]
        public async Task<IActionResult> Add([FromBody] OrderDto orderModel)
        {
            var order = await _orderService.CreateAsync(orderModel);

            return Ok(order);
        }

        [HttpPut("order")]
        public async Task<IActionResult> Update([FromBody] OrderDto orderModel)
        {
            var order = await _orderService.UpdateAsync(orderModel);

            return Ok(order);
        }

        [HttpDelete("order")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
