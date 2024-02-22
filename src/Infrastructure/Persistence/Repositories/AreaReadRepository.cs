using Application.AreaFeatures.Queries.DTOs;
using Domain.Model.AreaAggregate;
using Infrastructure.Persistence.Repositories.Contracts;
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