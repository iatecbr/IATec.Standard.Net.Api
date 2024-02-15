using Application.AreaFeatures.Queries.DTOs;

namespace Application.AreaFeatures.Queries;

public interface IAreaQueries
{
    AreaDto? GetAreaById(int areaId);
}