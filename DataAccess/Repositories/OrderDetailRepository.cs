using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(NorthwindContext context) : base(context) 
        { 
        }
    }
}
