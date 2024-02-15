using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AreaRepository(DataContext dataContext) : IAreaRepository
{
    public async Task SaveAreaAsync(Area area)
    {
        await dataContext.Area.AddAsync(area);
    }

    public async Task<Area?> GetAreaById(int areaId)
    {
        var area = await dataContext.Area.
            FirstOrDefaultAsync(a => a.Id == areaId);

        return area;
    }
}