using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task DeleteOrderDetails(int orderId);
    }
}
