using Application.AreaFeatures.Queries;
using Application.AreaFeatures.Queries.DTOs;
using Domain.Contracts.Repositories.Generic;
using Domain.Model.AreaAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries;

internal sealed class GetAreaQueryHandler(IGenericRepositoryQuery genericRepositoryQuery) 
    : IRequestHandler<GetAreaQuery, AreaReadDto?>
{
    public async Task<AreaReadDto?> Handle(GetAreaQuery request, CancellationToken cancellationToken)
    {    
        var area = await genericRepositoryQuery.Query<Area>()
            .Where(a => a.Id == request.AreaId)
            .Select(s => new AreaReadDto(s.Name, s.Manager))
            .FirstOrDefaultAsync(cancellationToken);

        return area;
    }
}