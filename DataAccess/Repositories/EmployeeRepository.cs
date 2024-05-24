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

        public async Task SoftDeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                employee.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
