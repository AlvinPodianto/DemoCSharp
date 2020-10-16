using DemoDataService;
using DemoDataService.CQRS.Commands;
using DemoDataService.CQRS.Queries;
using MediatR;
using Moq;
using System.Threading;

namespace DemoDataServiceTest.Mocks
{
    public class MockMediator
    {
        private DemoContext _context;
        private MockHandler _handler;

        public MockMediator(DemoContext context)
        {
            _context = context;
            _handler = new MockHandler(_context);
        }

        public Mock<IMediator> Init() 
        {
            var mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(It.IsAny<CreateDepartementCommand>(), It.IsAny<CancellationToken>()))
                    .Returns<CreateDepartementCommand, CancellationToken>((x, y) => _handler.CreateDepartementHandler.Handle(x, y));

            mediator.Setup(m => m.Send(It.IsAny<GetDepartementByIdQuery>(), It.IsAny<CancellationToken>()))
                    .Returns<GetDepartementByIdQuery, CancellationToken>((x, y) => _handler.GetDepartementByIdHandler.Handle(x, y));

            return mediator;
        }
    }
}