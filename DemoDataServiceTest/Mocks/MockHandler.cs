using DemoDataService;
using DemoDataService.CQRS.Commands;
using DemoDataService.CQRS.Queries;

namespace DemoDataServiceTest.Mocks
{
    public class MockHandler
    {
        private readonly MockRepository _repository;

        public readonly CreateDepartementHandler CreateDepartementHandler;
        public readonly GetDepartementByIdHandler GetDepartementByIdHandler;

        public MockHandler(DemoContext context)
        {
            _repository = new MockRepository(context);

            CreateDepartementHandler = new CreateDepartementHandler(_repository.DepartementRepository);

            GetDepartementByIdHandler = new GetDepartementByIdHandler(_repository.DepartementRepository);
        }
    }
}
