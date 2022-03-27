using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTO;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
        {
            var employees = await _employeeService.GetEmployeesAsync(companyId, false);

            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = await _employeeService.GetEmployeeAsync(companyId, id, false);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Guid companyId, [FromBody] CreateEmployeeDto employee)
        {
            if (employee is null)
                return BadRequest("CreateEmployeeDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var employeeToReturn = await _employeeService.CreateEmployeeAsync(companyId, employee, false);

            return CreatedAtAction("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid companyId, Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(companyId, id, false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid companyId, Guid id, [FromBody] UpdateEmployeeDto employee)
        {
            if (employee is null)
                return BadRequest("UpdateEmployeeDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _employeeService.UpdateEmployeeAsync(companyId, id, employee, false, true);

            return NoContent();
        }
    }
}