using Service.DTO;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges);
        Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        Task<EmployeeDto> CreateEmployeeAsync(Guid companyId, CreateEmployeeDto employee, bool trackChanges);
        Task UpdateEmployeeAsync(Guid companyId, Guid id, UpdateEmployeeDto employee, bool compTrackChanges, bool empTrackChanges);
        Task DeleteEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
    }
}
