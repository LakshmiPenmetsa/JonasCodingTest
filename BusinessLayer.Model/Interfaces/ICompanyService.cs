using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        Task<CompanyInfo> GetCompanyByName(string companyName);
        Task<bool> Post(CompanyInfo companyInfo);
        Task<bool> Put(CompanyInfo companyInfo);
        Task<bool> Delete(int id);
    }
}
