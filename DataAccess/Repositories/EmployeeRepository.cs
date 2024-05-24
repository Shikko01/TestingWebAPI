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

        public async Task<IEnumerable<Employee>> GetEmployeesAboveAge(int targetAge)
        {
            var cutoffDate = DateTime.Now.AddYears(-targetAge);

            return await _context.Employees.Where(e => e.BirthDate.HasValue && e.BirthDate < cutoffDate).ToListAsync();
        }
    }

}
