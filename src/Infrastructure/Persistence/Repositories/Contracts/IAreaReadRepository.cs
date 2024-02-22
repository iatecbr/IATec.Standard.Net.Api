using Application.AreaFeatures.Queries.DTOs;
using Domain.Contracts.Repositories.Generic;
using Domain.Model.AreaAggregate;

namespace Infrastructure.Persistence.Repositories.Contracts;

public interface IAreaReadRepository : IReadRepository<Area>
{
    Task<List<AreaSquadReadDto>> GetAreaSquadListAsync();
}