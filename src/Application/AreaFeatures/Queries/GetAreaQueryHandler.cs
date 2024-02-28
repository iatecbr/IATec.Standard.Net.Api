using Application.AreaFeatures.Queries.DTOs;
using Domain.Contracts.Repositories.Generic;
using Domain.Model.AreaAggregate;
using MediatR;

namespace Application.AreaFeatures.Queries;

internal sealed class GetAreaQueryHandler(IGenericRepositoryQuery genericRepositoryQuery) 
    : IRequestHandler<GetAreaQuery, AreaReadDto?>
{
    public async Task<AreaReadDto?> Handle(GetAreaQuery request, CancellationToken cancellationToken)
    {    
        var area = genericRepositoryQuery.Query<Area>()
            .Where(a => a.Id == request.AreaId)
            .Select(s => new AreaReadDto(s.Name, s.Manager))
            .FirstOrDefault();
    
        return await Task.FromResult(area);
    }
}