using Departments.DAL.EF.Context.Contracts;
using Departments.DAL.Models.DomainModels;
using Departments.DAL.Repositories.Contracts;

namespace Departments.DAL.Repositories.Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {

        }
        
    }
}