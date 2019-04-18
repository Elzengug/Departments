using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Departments.DAL.Models.DomainModels;

namespace Departments.ViewModels.Converters
{
    public static class ViewToData
    {
        public static Department ConvertDepartment(DepartmentViewModel model)
        {
            return new Department
            {   Id = model.Id,
                Name = model.Name
            };
        }
        public static Employee ConvertEmployee(EmployeeViewModel model)
        {
            return new Employee
            {   
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Email = model.Email,
                EmployeementDate = DateTime.Parse(model.EmployeementDate),
                DepartmentId = model.DepartmentId
            };
        }
    }
}
