using System;

namespace Departments.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeementDate { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
    }
}