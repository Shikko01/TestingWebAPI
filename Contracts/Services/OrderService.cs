using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository; 
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderDetailRepository.DeleteOrderDetails(orderId);

            await _orderRepository.DeleteAsync(p => p.OrderId == orderId);
        }
    }
}
