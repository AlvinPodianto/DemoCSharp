using DemoDataService.Contracts;
using DemoDataService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemoDataService.Repos
{
    public class DepartementRepository : BaseRepository<Department>, IDepartementRepository
    {
        public DepartementRepository(DemoContext context) : base(context) { }

        public override Department GetById(long id) =>
            Context.Set<Department>().Include(x => x.Employees).SingleOrDefault(x=> x.Id == id);
    }

    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DemoContext context) : base(context) { }
    }
}