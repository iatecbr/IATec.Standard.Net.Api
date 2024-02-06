using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;

namespace Infrastructure.Persistence.Repositories;

public class AreaRepository(DataContext dataContext) : IAreaRepository
{
    public async Task SaveAreaAsync(Area area)
    {
        await dataContext.Area.AddAsync(area);
    }
}