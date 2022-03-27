using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTO;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService; 

        public CompaniesController(ICompanyService service)
        {
            _companyService = service;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync(false);

            return Ok(companies);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _companyService.GetCompanyAsync(id, false);

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto company)
        {
            if (company is null)
                return BadRequest("CreateCompanyDto object is null");

            var createdCompany = await _companyService.CreateCompanyAsync(company);

            return CreatedAtAction("GetCompany", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _companyService.DeleteCompanyAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyDto company)
        {
            if (company is null)
                return BadRequest("UpdateCompany object is null");

            await _companyService.UpdateCompanyAsync(id, company, true);

            return NoContent();
        }
    }
}