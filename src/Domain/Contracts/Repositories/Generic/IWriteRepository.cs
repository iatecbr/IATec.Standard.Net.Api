using Domain.SeedWorks;

namespace Domain.Contracts.Repositories.Generic;

public interface IWriteRepository<T> : IReadRepository<T>, IUnitOfWork where T : class
{
    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    void Remove(T item);

    void RemoveRange(IEnumerable<T> entities);

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);
}