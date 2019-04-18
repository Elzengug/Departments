using Departments.DAL.EF.Context.Contracts;
using Departments.DAL.Models.DomainModels;
using Departments.DAL.Repositories.Contracts;

namespace Departments.DAL.Repositories.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}