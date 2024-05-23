using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeRepository(NorthwindContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAboveAge(int targetAge)
        {
            var cutoffDate = DateTime.Now.AddYears(-targetAge);

            return await _context.Employees.Where(e => e.BirthDate < cutoffDate).ToListAsync();
        }
    }
}
