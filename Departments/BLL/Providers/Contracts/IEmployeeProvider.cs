using System.Collections.Generic;
using System.Threading.Tasks;
using Departments.DAL.Models.DomainModels;

namespace Departments.BLL.Providers.Contracts
{
    public interface IEmployeeProvider
    {
        Task<ICollection<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<ICollection<Employee>> GetEmployeesByDepartmentIdAsync(int id);
        Task<bool> RemoveEmployeeAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> EditEmployeeAsync(Employee employee);
    }
}