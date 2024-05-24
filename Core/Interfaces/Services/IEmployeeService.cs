using Core.DTO;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeCreateUpdateDTO> CreateEmployeeAsync(EmployeeCreateUpdateDTO employee);
        Task<EmployeeCreateUpdateDTO> UpdateEmployeeAsync(int id, EmployeeCreateUpdateDTO employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAboveAge(int targetAge);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesByCountryAsync(string country);
    }
}
