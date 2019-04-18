using System.Collections.Generic;
using Departments.DAL.Models.DomainModels;

namespace Departments.ViewModels
{
    public class EmployeePageViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}