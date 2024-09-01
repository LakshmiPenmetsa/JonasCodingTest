using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using BusinessLayer.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;

        }

        // GET api/<controller>/code
        public async Task<EmployeeDto> GetEmployeeByCode(string employeeCode)
        {
            try
            {
                var item = await _employeeService.GetEmployeeByCode(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured at GetEmployeeByCode");
                throw ex;
            }
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody] EmployeeCreateInfo employeecreateInfo)
        {
            try
            {
                return await _employeeService.Post(employeecreateInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured at Post");
                return false;
            }
        }
    }
}