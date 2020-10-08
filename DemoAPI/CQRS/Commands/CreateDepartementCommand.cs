using DemoAPI.Contracts;
using DemoAPI.Models;
using DemoAPI.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.CQRS.Commands
{
    public class CreateDepartementCommand : IRequest<SuccessResponse>
    {
        public CreateDepartemenVM Payload { get; set; }
    }

    public class CreateDepartementHandler : IRequestHandler<CreateDepartementCommand, SuccessResponse>
    {
        private readonly IDepartementRepository _repository;

        public CreateDepartementHandler(IDepartementRepository departementRepository) =>
            _repository = departementRepository;

        public Task<SuccessResponse> Handle(CreateDepartementCommand command, CancellationToken cancellationToken)
        {
            var result = new SuccessResponse();

            var departements = _repository.GetEntities(x => x.Name.ToLower().Contains(command.Payload.Name.ToLower()));

            if (departements.Count() != 0)
                result.Reason = $"Departement '{command.Payload.Name}' already existed.";
            else
            {
                var department = new Department
                {
                    Name = command.Payload.Name,
                    Location = command.Payload.Location
                };

                _repository.Create(department);

                result.Success = true;
            }

            return Task.Run(() => result);
        }
    }
}