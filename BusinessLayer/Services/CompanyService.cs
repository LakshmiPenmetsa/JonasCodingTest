using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllCompanies()
        {
            var res = await _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<CompanyInfo> GetCompanyByCode(string companyCode)
        {
            var result = await _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<CompanyInfo> GetCompanyByName(string companyName)
        {
            var result = await _companyRepository.GetByCode(companyName);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<bool> Post(CompanyInfo companyInfo)
        {
            var companyEntity = _mapper.Map<Company>(companyInfo);
            return await _companyRepository.Post(companyEntity);
        }

        public async Task<bool> Put(CompanyInfo companyInfo)
        {
            var companyEntity =  _mapper.Map<Company>(companyInfo);
            return await _companyRepository.Put(companyEntity);
        }
        public async Task<bool> Delete(int id) 
        {
            return await _companyRepository.Delete(id);
        }
    }
}
