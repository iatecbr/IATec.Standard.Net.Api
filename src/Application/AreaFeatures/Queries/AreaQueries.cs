using Application.AreaFeatures.Queries.DTOs;
using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;

namespace Application.AreaFeatures.Queries;

public class AreaQueries(IRepositoryQuery repositoryQuery) : IAreaQueries
{
    public AreaDto? GetAreaById(int areaId)
    {
        var area = repositoryQuery.Query<Area>()
            .Where(a => a.Id == areaId)
            .Select(s => new AreaDto(s.Name, s.Manager))
            .FirstOrDefault();

        return area;
    }
}