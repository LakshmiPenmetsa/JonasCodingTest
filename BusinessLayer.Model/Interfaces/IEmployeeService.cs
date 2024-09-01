using BusinessLayer.Model.Models;
using System.Threading.Tasks;
using WebApi.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeInfo> GetEmployeeByCode(string employeeCode);
        Task<bool> Post(EmployeeCreateInfo employeeCreateInfo);
    }
}
