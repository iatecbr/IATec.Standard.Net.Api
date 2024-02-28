using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate.DTOs;
using MediatR;

namespace Application.AreaFeatures.Queries;

internal sealed class GetAreaSquadQueryHandler(IAreaReadRepository areaReadRepository) 
    : IRequestHandler<GetAreaSquadQuery, List<AreaSquadReadDto>>
{
    public async Task<List<AreaSquadReadDto>> Handle(GetAreaSquadQuery request, CancellationToken cancellationToken)
    {
        return await areaReadRepository.GetAreaSquadListAsync();
    }
}