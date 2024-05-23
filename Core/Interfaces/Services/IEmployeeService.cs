using Core.DTO;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<EmployeeUpdateDTO> UpdateEmployeeAsync(int id, EmployeeUpdateDTO employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAboveAge(int targetAge);
    }
}
