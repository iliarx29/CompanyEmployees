using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Service.Implementations
{
    //public class ServiceManager : IServiceManager
    //{
    //    private ICompanyService? _companyService;
    //    private IEmployeeService? _employeeService;
    //    private IAuthenticationService? _authenticationService;
    //    private readonly IUnitOfWork _uow;
    //    private readonly ILogger<ServiceManager> _logger;
    //    private readonly IConfiguration _configuration;
    //    private readonly IMapper _mapper;
    //    private readonly UserManager<User> _userManager;

    //    public ServiceManager(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager, 
    //        ILogger<ServiceManager> logger, IConfiguration configuration)
    //    {
    //        _uow = uow;
    //        _mapper = mapper;
    //        _userManager = userManager;
    //        _logger = logger;
    //        _configuration = configuration;
    //    }

    //    public ICompanyService CompanyService
    //    {
    //        get
    //        {
    //            if (_companyService == null)
    //                _companyService = new CompanyService(_uow, _mapper);
    //            return _companyService;
    //        }
    //    }

    //    public IEmployeeService EmployeeService
    //    {
    //        get
    //        {
    //            if (_employeeService == null)
    //                _employeeService = new EmployeeService(_uow, _mapper);
    //            return _employeeService;
    //        }
    //    }
    //    public IAuthenticationService AuthenticationService
    //    {
    //        get
    //        {
    //            if (_authenticationService == null)
    //                _authenticationService = new AuthenticationService(_mapper, _logger, _userManager, _configuration);
    //            return _authenticationService;
    //        }
    //    }
    //}
}
