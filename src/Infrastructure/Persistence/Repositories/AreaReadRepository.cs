using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;
using Domain.Model.AreaAggregate.DTOs;
using Infrastructure.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AreaReadRepository(ReadDataContext readDataContext) 
    : ReadRepository<Area>(readDataContext), IAreaReadRepository
{
    public async Task<List<AreaSquadReadDto>> GetAreaSquadListAsync()
    {
        var areaSquadList = await readDataContext.Squad
            .Include(a => a.Area)
            .Select(squad => new AreaSquadReadDto(squad.Area.Name!, squad.Name!))
            .ToListAsync();

        return areaSquadList;
    }
}