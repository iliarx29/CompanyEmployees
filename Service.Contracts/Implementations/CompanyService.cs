using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Interfaces;
using Service.DTO;

namespace Service.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
        {
            var companies = await _uow.Company.GetAllCompaniesAsync(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid id, bool trackChanges)
        {
            var company = await _uow.Company.GetCompanyAsync(id, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(id);

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public async Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _uow.Company.CreateCompany(companyEntity);
            await _uow.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyToReturn;
        }

        public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
        {
            var company = await _uow.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            _uow.Company.DeleteCompany(company);
            await _uow.SaveAsync();
        }

        public async Task UpdateCompanyAsync(Guid companyId, UpdateCompanyDto company, bool trackChanges)
        {
            var companyEntity = await _uow.Company.GetCompanyAsync(companyId, trackChanges);
            if (companyEntity is null)
                throw new CompanyNotFoundException(companyId);

            _mapper.Map(company, companyEntity);
            await _uow.SaveAsync();
        }
    }
}