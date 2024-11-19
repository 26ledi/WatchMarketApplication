using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IBaseRepository<OrderDetail> _orderDetailRepository;
        private readonly IBaseRepository<Price> _priceRepository;

        public OrderDetailService(IBaseRepository<OrderDetail> orderDetailRepository, IBaseRepository<Price> priceRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _priceRepository = priceRepository;
        }
        public async Task<OrderDetailDto> CreateAsync(OrderDetailDto orderDetailDto)
        {
            var newOrderDetail = new OrderDetail
            {
                OrderId = orderDetailDto.OrderId,
                Quantity = orderDetailDto.Quantity,
                Price = GetFinalSum(orderDetailDto.Quantity, orderDetailDto.Price),
                WatchId = orderDetailDto.WatchId
            };

            await _orderDetailRepository.AddAsync(newOrderDetail);

            return new OrderDetailDto
            {
                OrderId = orderDetailDto.OrderId,
                Quantity = orderDetailDto.Quantity,
                Price = newOrderDetail.Price,
                WatchId = orderDetailDto.WatchId
            };
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetailLooked = await _orderDetailRepository.GetByIdAsync(id)
            ?? throw new Exception("This orderDetail detail does not exist");

            await _orderDetailRepository.DeleteAsync(orderDetailLooked);
        }

        public async Task<List<OrderDetailDto>> GetAllAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();

            var orderDto = orderDetails.Select(orderDetail => new OrderDetailDto
            {
                OrderId = orderDetail.OrderId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                WatchId = orderDetail.WatchId
            }).ToList();

            return orderDto;
        }

        public async Task<OrderDetailDto> UpdateAsync(OrderDetailDto orderDetailDto)
        {
            var orderDetailLooked = await _orderDetailRepository.GetByIdAsync(orderDetailDto.Id)
                            ?? throw new Exception("This orderDetail does not exist");

            orderDetailLooked.OrderId = orderDetailDto.OrderId;
            orderDetailLooked.Quantity = orderDetailDto.Quantity;
            orderDetailLooked.Price = GetFinalSum(orderDetailDto.Quantity, orderDetailDto.Price);
            orderDetailLooked.WatchId = orderDetailDto.WatchId;

            var updatedOrderDetail = await _orderDetailRepository.UpdateAsync(orderDetailLooked);

            return new OrderDetailDto
            {
                OrderId = updatedOrderDetail.OrderId,
                Quantity = updatedOrderDetail.Quantity,
                Price = updatedOrderDetail.Price,
                WatchId = updatedOrderDetail.WatchId
            };
        }

        private  double GetFinalSum(int quantity, double price) 
        {
            var finalSum = price * quantity;

            return finalSum;
        }
    }
}
