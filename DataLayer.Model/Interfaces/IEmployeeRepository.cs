using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByCode(string employeeCode);
        Task<bool> Post(Employee company);
    }
}
