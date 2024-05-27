using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<bool> ExistsAsync(string firstName, string lastName);
    }
}
