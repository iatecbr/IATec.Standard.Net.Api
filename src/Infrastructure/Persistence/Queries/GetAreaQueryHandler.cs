using Application.AreaFeatures.Queries;
using Application.AreaFeatures.Queries.DTOs;
using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries;

internal sealed class GetAreaQueryHandler(IRepositoryQuery repositoryQuery) 
    : IRequestHandler<GetAreaQuery, AreaDto?>
{
    public async Task<AreaDto?> Handle(GetAreaQuery request, CancellationToken cancellationToken)
    {    
        var area = await repositoryQuery.Query<Area>()
            .Where(a => a.Id == request.AreaId)
            .Select(s => new AreaDto(s.Name, s.Manager))
            .FirstOrDefaultAsync(cancellationToken);

        return area;
    }
}