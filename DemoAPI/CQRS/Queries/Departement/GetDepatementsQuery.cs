using DemoAPI.Contracts;
using DemoAPI.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.CQRS.Queries
{
    public class GetDepatementsQuery : IRequest<List<DepartementVM>>
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }

    public class GetDepatementsHandler : IRequestHandler<GetDepatementsQuery, List<DepartementVM>>
    {
        private readonly IDepartementRepository _repository;

        public GetDepatementsHandler(IDepartementRepository departementRepository) =>
            _repository = departementRepository;

        public Task<List<DepartementVM>> Handle(GetDepatementsQuery query, CancellationToken cancellationToken)
        {
            var departments = _repository.GetEntities();

            return Task.Run(() => departments.Select(x => new DepartementVM
                                                       {
                                                           Id = x.Id,
                                                           Name = x.Name,
                                                           Location = x.Location
                                                       })
                                             .Skip(query.ItemsPerPage * (query.Page - 1))
                                             .Take(query.ItemsPerPage)
                                             .ToList() 
            );
        }
    }
}