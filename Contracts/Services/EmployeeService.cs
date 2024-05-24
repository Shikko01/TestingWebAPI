using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var model = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return model;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<EmployeeCreateUpdateDTO> UpdateEmployeeAsync(int id, EmployeeCreateUpdateDTO employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.BirthDate = employee.BirthDate;
            existingEmployee.Country = employee.Country;

            var updateEmployee = await _employeeRepository.UpdateAsync(existingEmployee);

            var model = _mapper.Map<EmployeeCreateUpdateDTO>(updateEmployee);

            return model;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(id);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAboveAge(int targetAge)
        {
            var cutoffDate = DateTime.Now.AddYears(-targetAge);

            var employees = await _employeeRepository.GetAsync(e => e.BirthDate.HasValue && e.BirthDate < cutoffDate);

            var model = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return model;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByCountryAsync(string country)
        {
            var employees = await _employeeRepository.GetAsync(e => e.Country == country);

            var model = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return model;
        }
    }
}
