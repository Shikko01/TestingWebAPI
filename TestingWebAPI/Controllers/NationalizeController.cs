using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalizeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly INationalizeService _nationalizeService;

        public NationalizeController(IEmployeeService employeeService, INationalizeService nationalizeService)
        {
            _employeeService = employeeService;
            _nationalizeService = nationalizeService;
        }

        [HttpGet("{id}/nationalities")]
        public async Task<ActionResult<IEnumerable<NationalizeResponseDTO>>> GetEmployeeNationalities(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var nationalities = await _nationalizeService.GetNationalitiesAsync(employee.FirstName);

            return Ok(nationalities);
        }
    }
}
