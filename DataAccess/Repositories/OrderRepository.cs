using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
