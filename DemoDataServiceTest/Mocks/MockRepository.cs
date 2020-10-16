using DemoDataService;
using DemoDataService.Contracts;
using DemoDataService.Repos;

namespace DemoDataServiceTest.Mocks
{
    public class MockRepository
    {
        public readonly IDepartementRepository DepartementRepository;
        public readonly IEmployeeRepository EmployeeRepository;

        public MockRepository(DemoContext context)
        {
            DepartementRepository = new DepartementRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
        }
    }
}