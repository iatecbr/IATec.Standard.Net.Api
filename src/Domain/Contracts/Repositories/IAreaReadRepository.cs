using Domain.Contracts.Repositories.Generic;
using Domain.Model.AreaAggregate;
using Domain.Model.AreaAggregate.DTOs;

namespace Domain.Contracts.Repositories;

public interface IAreaReadRepository : IReadRepository<Area>
{
    Task<List<AreaSquadReadDto>> GetAreaSquadListAsync();
}