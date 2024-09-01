using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;
using WebApi.Models;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository,
                               ICompanyService companyService,
                               IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<EmployeeInfo> GetEmployeeByCode(string employeeCode)
        {
            var employeeDetails = _mapper.Map<EmployeeInfo>(await _employeeRepository.GetEmployeeByCode(employeeCode));
            var companyDetails = await _companyService.GetCompanyByName(employeeDetails.CompanyName);

            if (employeeDetails != null && companyDetails != null)
            {
                employeeDetails.SiteId = companyDetails.SiteId;
                employeeDetails.CompanyCode = companyDetails.CompanyCode;
            }
            return employeeDetails;
        }

        public async Task<bool> Post(EmployeeCreateInfo employeeCreateInfo)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeCreateInfo);
            return await _employeeRepository.Post(employeeEntity);
        }
    }
}
