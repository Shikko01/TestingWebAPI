using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
