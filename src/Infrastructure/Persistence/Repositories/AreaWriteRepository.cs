using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;
using Infrastructure.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AreaWriteRepository(WriteDataContext writeDataContext) 
    : WriteRepository<Area>(writeDataContext), IAreaWriteRepository
{
    public async Task<List<Area>> ResearchAreaByFilterAsync(string filter)
    {
        var areaList = await writeDataContext.Area
            .Where(a => a.Name!.Contains(filter))
            .ToListAsync();

        return areaList;
    }
}