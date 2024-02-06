using Domain.Model.AreaAggregate;

namespace Domain.Contracts.Repositories;

public interface IAreaRepository
{
    Task SaveAreaAsync(Area area);
}