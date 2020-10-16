using DemoDataService;
using DemoDataService.CQRS.Commands;
using DemoDataService.Models;
using DemoDataService.ViewModels;
using DemoDataServiceTest.Mocks;
using MediatR;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DemoDataServiceTest.Commands
{
    public class CreateDepartementCommandTest
    {
        private readonly DemoContext _context;
        private readonly Mock<IMediator> _mediatr;

        public CreateDepartementCommandTest(DemoContext context = null)
        {
            _context = context != null ? context : new MockDbContext().Create();
            _mediatr = new MockMediator(_context).Init();
        }

        [Fact]
        public async Task Success_CreateDepartement() 
        {
            // Arrange
            var command = new CreateDepartementCommand
                          {
                              Payload = new CreateDepartemenVM
                                        {
                                            Name = "Test Success Name",
                                            Location = "Test Success Location"
                                        }
                          };

            // Act
            var result = await _mediatr.Object.Send(command, default);
            
            // Assert
            Assert.IsType<SuccessResponse>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Failed_CreateDepartement() 
        {
            // Arrange
            await Success_CreateDepartement();
            var command = new CreateDepartementCommand
                          {
                              Payload = new CreateDepartemenVM
                                        {
                                            Name = "Test Success Name",
                                            Location = "Test Success Location"
                                        }
                          };

            // Act
            var result = await _mediatr.Object.Send(command, default);
            
            // Assert
            Assert.IsType<SuccessResponse>(result);
            Assert.False(result.Success);
        }
    }
}