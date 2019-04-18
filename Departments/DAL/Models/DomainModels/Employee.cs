using System;
using System.Collections.Generic;

namespace Departments.DAL.Models.DomainModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime EmployeementDate { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}