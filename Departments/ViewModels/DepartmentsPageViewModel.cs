using System.Collections.Generic;
using Departments.DAL.Models.DomainModels;

namespace Departments.ViewModels
{
    public class DepartmentsPageViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public  PageViewModel PageViewModel { get; set; }
    }
}