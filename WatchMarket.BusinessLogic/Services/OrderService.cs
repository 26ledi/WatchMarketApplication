using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;
        public OrderService(IBaseRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> CreateAsync(OrderDto orderDto)
        {
            var newOrder = new Order
            {
                UserId = orderDto.UserId,
                OrderDate = orderDto.OrderDate
            };

            await _orderRepository.AddAsync(newOrder);

            return new OrderDto
            {
                UserId = newOrder.UserId,
                OrderDate = newOrder.OrderDate
            };
        }

        public async Task DeleteAsync(int id)
        {
            var orderLooked = await _orderRepository.GetByIdAsync(id)
            ?? throw new Exception("This order does not exist");

            await _orderRepository.DeleteAsync(orderLooked);
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            var orderDto = orders.Select(order => new OrderDto
            {
                UserId = order.UserId,
                OrderDate = order.OrderDate
            }).ToList();

            return orderDto;
        }

        public async Task<OrderDto> UpdateAsync(OrderDto orderDto)
        {
            var orderLooked = await _orderRepository.GetByIdAsync(orderDto.Id)
                            ?? throw new Exception("This order does not exist");

            orderLooked.UserId = orderDto.UserId;
            orderLooked.OrderDate = orderDto.OrderDate;

            var updatedOrder = await _orderRepository.UpdateAsync(orderLooked);

            return new OrderDto
            {
                UserId = updatedOrder.UserId,
                OrderDate = updatedOrder.OrderDate
            };
        }
    }
}
