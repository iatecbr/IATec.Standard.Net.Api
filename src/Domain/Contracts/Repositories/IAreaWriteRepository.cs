using Domain.Contracts.Repositories.Generic;
using Domain.Model.AreaAggregate;

namespace Domain.Contracts.Repositories;

public interface IAreaWriteRepository : IWriteRepository<Area>
{
    Task<List<Area>> ResearchAreaByFilterAsync(string filter);
}