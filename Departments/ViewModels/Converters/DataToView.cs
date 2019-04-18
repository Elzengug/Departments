using Departments.DAL.Models.DomainModels;

namespace Departments.ViewModels.Converters
{
    public static class DataToView
    {
        public static DepartmentViewModel ConvertDepartment(Department model)
        {
            return new DepartmentViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static EmployeeViewModel ConvertEmployee(Employee model)
        {
            return new EmployeeViewModel
            {   
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Email = model.Email,
                EmployeementDate = model.EmployeementDate.ToShortDateString(),
                
            };
        }
    }
}