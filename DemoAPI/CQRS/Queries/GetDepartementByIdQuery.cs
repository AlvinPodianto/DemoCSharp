using DemoAPI.Contracts;
using DemoAPI.ViewModels;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.CQRS.Queries
{
    public class GetDepartementByIdQuery : IRequest<DepartementDetailVM>
    {
        public long Id { get; set; }
    }

    public class GetDepartementByIdHandler : IRequestHandler<GetDepartementByIdQuery, DepartementDetailVM>
    {
        private readonly IDepartementRepository _repository;

        public GetDepartementByIdHandler(IDepartementRepository departementRepository) =>
            _repository = departementRepository;

        public Task<DepartementDetailVM> Handle(GetDepartementByIdQuery query, CancellationToken cancellationToken)
        {
            var departement = _repository.GetById(query.Id);

            if (departement == null)
                throw new NullReferenceException($"Departement with ID '{query.Id}' not found.");
            else
                return Task.Run(() => new DepartementDetailVM
                                      {
                                          Id = departement.Id,
                                          Name = departement.Name,
                                          Location = departement.Location,
                                          Employees = departement.Employees.Select(y => new EmployeeVM
                                                                                     {
                                                                                         Id = y.Id,
                                                                                         FirstName = y.FirstName,
                                                                                         LastName = y.LastName,
                                                                                         JoinDate = y.JoinDate
                                                                                     })
                                                                           .ToList()
                                      }
                );
        }
    }
}