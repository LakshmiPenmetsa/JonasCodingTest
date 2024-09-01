using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetByCode(string companyCode);
        Task<Company> GetCompanyByName(string companyName);
        Task<bool> Post(Company company);
        Task<bool> Put(Company company);
        Task<bool> Delete(int id);
    }
}
