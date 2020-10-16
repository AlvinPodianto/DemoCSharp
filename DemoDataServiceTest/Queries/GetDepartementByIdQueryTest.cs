using DemoDataService;
using DemoDataService.CQRS.Queries;
using DemoDataService.ViewModels;
using DemoDataServiceTest.Commands;
using DemoDataServiceTest.Mocks;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DemoDataServiceTest.Queries
{
    public class GetDepartementByIdQueryTest
    {
        private readonly DemoContext _context;
        private readonly Mock<IMediator> _mediatr;

        private readonly CreateDepartementCommandTest _createDepartementCommandTest;

        public GetDepartementByIdQueryTest(DemoContext context = null)
        {
            _context = context != null ? context : new MockDbContext().Create();
            _mediatr = new MockMediator(_context).Init();

            _createDepartementCommandTest = new CreateDepartementCommandTest(_context);
        }

        [Fact]
        public async Task Success_GetDepartementByIdQuery() 
        {
            // Arrange
            await _createDepartementCommandTest.Success_CreateDepartement();
            var query = new GetDepartementByIdQuery { Id = 1 };

            // Act
            var result = await _mediatr.Object.Send(query, default);

            // Assert
            Assert.IsType<DepartementDetailVM>(result);
            Assert.Equal("Test Success Name", result.Name);
        }

        [Fact]
        public async Task Failed_GetDepartementByIdQuery() 
        {
            // Arrange
            var query = new GetDepartementByIdQuery
            {
                Id = 999,
            };

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _mediatr.Object.Send(query, default));
        }
    }
}
