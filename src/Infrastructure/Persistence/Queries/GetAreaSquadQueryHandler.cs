using Application.AreaFeatures.Queries;
using Application.AreaFeatures.Queries.DTOs;
using Infrastructure.Persistence.Repositories.Contracts;
using MediatR;

namespace Infrastructure.Persistence.Queries;

internal sealed class GetAreaSquadQueryHandler(IAreaReadRepository areaReadRepository) 
    : IRequestHandler<GetAreaSquadQuery, List<AreaSquadReadDto>>
{
    public async Task<List<AreaSquadReadDto>> Handle(GetAreaSquadQuery request, CancellationToken cancellationToken)
    {
        return await areaReadRepository.GetAreaSquadListAsync();
    }
}