using System.Collections.Generic;
using System.Threading.Tasks;
using Departments.DAL.Models.DomainModels;

namespace Departments.BLL.Providers.Contracts
{
    public interface IDepartmentProvider
    {
        Task<ICollection<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<bool> RemoveDepartmentAsync(int id);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> EditDepartmentAsync(Department department);
    }
}