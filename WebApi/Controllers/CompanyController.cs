using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BusinessLayer.Model.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;

        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<CompanyDto>>(
                    await _companyService.GetAllCompanies());
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex,"Error occured at GetAll");
                throw ex;
            }
           
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
                var item = await _companyService.GetCompanyByCode(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured at Get");
                throw ex;
            }          
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody]CompanyInfo companyInfo)
        {
            try
            {
                return await _companyService.Post(companyInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured at Post");
                return false;
            }
        }

        // PUT api/<controller>/5
        public async Task<bool> Put([FromBody] CompanyInfo companyInfo)
        {
            try
            {
                return await _companyService.Put(companyInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured at Put");
                return false;
            }
           
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _companyService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "Error occured at Delete");
                return false;
            }
          
        }
    }
}