using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeRepository(NorthwindContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
