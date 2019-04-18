using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Departments.BLL.Providers.Contracts;
using Departments.DAL.Models.DomainModels;
using Departments.DAL.Repositories.Contracts;

namespace Departments.BLL.Providers.Implementations
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeProvider(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ICollection<Employee>> GetAllEmployeesAsync()
        {
            var employee = await _employeeRepository.GetItemsAsync();
            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.FindFirstAsync(b => b.Id == id);
            return employee;
        }

        public async Task<ICollection<Employee>> GetEmployeesByDepartmentIdAsync(int id)
        {
            var employees = await _employeeRepository.FindAllAsync(x => x.DepartmentId == id);
            return employees;
        }

        public async Task<bool> RemoveEmployeeAsync(int id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            return await _employeeRepository.RemoveAsync(employee);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var emp = await _employeeRepository.FindFirstAsync(x => x.Email == employee.Email);
            if (emp != null)
            {
                throw new OperationCanceledException();
            }
            var addedEmployee = await _employeeRepository.AddAsync(employee);
            return addedEmployee;
        }

        public async Task<Employee> EditEmployeeAsync(Employee employee)
        {
            var emp = await _employeeRepository.FindFirstAsync(x => x.Email == employee.Email);
            if (emp != null)
            {
                throw new OperationCanceledException();
            }
            var editEmployee = await _employeeRepository.UpdateAsync(employee);
            return editEmployee;
        }
    }
}