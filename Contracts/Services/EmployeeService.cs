using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var model = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return model;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return null;
            }

            var model = _mapper.Map<EmployeeDTO>(employee);

            return model;
        }

        public async Task<EmployeeCreateUpdateDTO> CreateEmployeeAsync(EmployeeCreateUpdateDTO employee)
        {
            EnsureBirthDateValidation(employee);

            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Country = employee.Country,
            };

            await EnsureEmployeeDoesNotAlreadyExistAsync(newEmployee);

            var createdEmployee = await _employeeRepository.AddAsync(newEmployee);

            var model = _mapper.Map<EmployeeCreateUpdateDTO>(createdEmployee);

            return model;
        }

        public async Task<EmployeeCreateUpdateDTO> UpdateEmployeeAsync(int id, EmployeeCreateUpdateDTO employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(e => e.EmployeeId == id);

            if (existingEmployee == null)
            {
                return null;
            }

            EnsureBirthDateValidation(employee);

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.BirthDate = employee.BirthDate;
            existingEmployee.Country = employee.Country;

            await EnsureEmployeeDoesNotAlreadyExistAsync(existingEmployee);

            var updateEmployee = await _employeeRepository.UpdateAsync(existingEmployee);

            var model = _mapper.Map<EmployeeCreateUpdateDTO>(updateEmployee);

            return model;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(e => e.EmployeeId == id);

            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(p => p.EmployeeId == id);
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

        public async Task<bool> SoftDeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(e => e.EmployeeId == id);

            if (existingEmployee == null)
            {
                return false;
            }

            existingEmployee.IsActive = false;

            await _employeeRepository.UpdateAsync(existingEmployee);

            return true;
        }

        private async Task EnsureEmployeeDoesNotAlreadyExistAsync(Employee employee)
        {
            if (await _employeeRepository.AnyExist(e => e.FirstName == employee.FirstName
                                                         && e.LastName == employee.LastName
                                                         && e.EmployeeId != employee.EmployeeId))
            { 
                throw new ValidationException("An employee with the same first and last name already exists.");
            }
        }

        private ValidationResult Validate(DateTime dateOfBirth)
        {
            if (dateOfBirth >= DateTime.Now)
            {
                return new ValidationResult("Date of birth cannot be in the future.");
            }

            if (!int.TryParse(_configuration["MinYear"], out var minYear))
            {
                return new ValidationResult("Invalid or missing 'MinYear' configuration.");
            }

            if (dateOfBirth.Year <= minYear)
            {
                return new ValidationResult($"Date of birth cannot be earlier then {minYear}.");
            }

            return ValidationResult.Success;
        }

        private void EnsureBirthDateValidation(EmployeeCreateUpdateDTO employee)
        {
            var validationResult = Validate(employee.BirthDate);

            if (validationResult != ValidationResult.Success)
            {
                throw new ValidationException(validationResult.ErrorMessage);
            }
        }
    }
}
