using DemoAPI.Contracts;

namespace DemoAPI.Repos
{
    public class DepartementRepository : BaseRepository, IDepartementRepository
    {
        public DepartementRepository(DemoContext context) : base(context) { }
    }

    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(DemoContext context) : base(context) { }
    }
}