using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
