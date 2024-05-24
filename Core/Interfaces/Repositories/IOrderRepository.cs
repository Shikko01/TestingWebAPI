using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task DeleteAsync(int id);
    }
}
