using Microsoft.AspNetCore.Mvc;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.Controllers
{
    [ApiController]
    [Route("watchmarket")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("orderDetails")]
        public async Task<IActionResult> GetAll()
        {
            var orderDetails = await _orderDetailService.GetAllAsync();

            return Ok(orderDetails);
        }

        [HttpPost("orderDetail")]
        public async Task<IActionResult> Add([FromBody] OrderDetailDto orderDetailModel)
        {
            var orderDetail = await _orderDetailService.CreateAsync(orderDetailModel);

            return Ok(orderDetail);
        }

        [HttpPut("orderDetail")]
        public async Task<IActionResult> Update([FromBody] OrderDetailDto orderDetailModel)
        {
            var orderDetail = await _orderDetailService.UpdateAsync(orderDetailModel);

            return Ok(orderDetail);
        }

        [HttpDelete("orderDetail")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderDetailService.DeleteAsync(id);

            return NoContent();
        }
    }
}
