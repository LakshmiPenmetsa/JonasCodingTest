using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }

        public async Task<Employee> GetEmployeeByCode(string employeeCode)
        {
            var employeedetails = await _employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(employeeCode));
            return employeedetails.FirstOrDefault();  
        }

        public async Task<bool> Post(Employee employee)
        {
            return await _employeeDbWrapper.InsertAsync(employee);
        }
    }
}
