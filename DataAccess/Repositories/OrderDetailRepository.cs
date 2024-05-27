using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(NorthwindContext context) : base(context) { }

        public async Task DeleteOrderDetails(int orderId)
        {
            var orderDetails = _context.OrderDetails.Where(o => o.OrderId == orderId);

            if (orderDetails != null)
            {
                _context.OrderDetails.RemoveRange(orderDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}
