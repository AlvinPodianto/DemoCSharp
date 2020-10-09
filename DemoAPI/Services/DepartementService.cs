using DemoDataService.CQRS.Commands;
using DemoDataService.ViewModels;
using Grpc.Core;
using MediatR;
using ServiceProto.Departement;
using System.Threading.Tasks;

namespace DemoDataService.Services
{
    public class DepartementService : ProtoDepartement.ProtoDepartementBase
    {
        private readonly IMediator _mediatr;

        public DepartementService(IMediator mediator) =>
            _mediatr = mediator;

        public override async Task<SuccessReply> AddDepartement(AddDepartementMessage request, ServerCallContext context)
        {
            var result = await _mediatr.Send(new CreateDepartementCommand { Payload = new CreateDepartemenVM { Name = request.Name, Location = request.Location } });
            return new SuccessReply { Success = result.Success, Reason = result.Reason };
        }
    }
}