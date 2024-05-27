using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();

            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeCreateUpdateDTO>> CreateEmployee(EmployeeCreateUpdateDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);

            return Ok(createdEmployee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeCreateUpdateDTO>))]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeCreateUpdateDTO employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        // DELETE: api/Employee/5
        [HttpPut("softDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _employeeService.SoftDeleteEmployeeAsync(id);

            return NoContent();
        }

        [HttpGet("aboveAge/{targetAge}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeDTO>))]
        public async Task<IActionResult> GetEmployeesAboveAge(int targetAge)
        {
            if (targetAge < 0)
            {
                return BadRequest("Target age cannot be negative.");
            }

            var employees = await _employeeService.GetEmployeesAboveAge(targetAge);

            if (employees == null || !employees.Any())
            {
                return NotFound("No employees found matching the criteria.");
            }

            return Ok(employees);
        }

        [HttpGet("byCountry/{country}")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByCountry(string country)
        {
            var employees = await _employeeService.GetEmployeesByCountryAsync(country);

            return Ok(employees);
        }
    }
}
