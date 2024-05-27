using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string firstName, string lastName)
        {
            return await _context.Employees.AnyAsync(e => e.FirstName.ToLower() == firstName.ToLower() 
                        && e.LastName.ToLower() == lastName.ToLower());
        }
    }
}
