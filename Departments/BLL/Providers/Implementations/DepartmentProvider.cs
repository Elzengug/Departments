using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Departments.BLL.Providers.Contracts;
using Departments.DAL.Models.DomainModels;
using Departments.DAL.Repositories.Contracts;

namespace Departments.BLL.Providers.Implementations
{
    public class DepartmentProvider : IDepartmentProvider
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentProvider(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<ICollection<Department>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetItemsAsync();
            return departments;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.FindFirstAsync(b => b.Id == id);
            return department;
        }

        public async Task<bool> RemoveDepartmentAsync(int id)
        {
            var department = await GetDepartmentByIdAsync(id);
            return await _departmentRepository.RemoveAsync(department);
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            var dep = await _departmentRepository.FindFirstAsync(x => x.Name == department.Name);
            if (dep != null)
            {
                throw new OperationCanceledException();
            }
            var addedDepartment = await _departmentRepository.AddAsync(department);
            return addedDepartment;
        }

        public async Task<Department> EditDepartmentAsync(Department department)
        {
            var dep = await _departmentRepository.FindFirstAsync(x => x.Name == department.Name);
            if (dep != null)
            {
                throw new OperationCanceledException();
            }
            var editDepartment = await _departmentRepository.UpdateAsync(department);
            return editDepartment;
        }
    }
}
