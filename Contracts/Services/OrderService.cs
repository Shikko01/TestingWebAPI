using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

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
            await _orderDetailRepository.DeleteAllAsync(oD => oD.OrderId == orderId);

            await _orderRepository.DeleteAsync(p => p.OrderId == orderId);
        }
    }
}
