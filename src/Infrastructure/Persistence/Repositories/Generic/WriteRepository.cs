using Domain.Contracts.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Generic;

public class WriteRepository<T>(DbContext dbContext) : ReadRepository<T>(dbContext), IWriteRepository<T> 
    where T : class
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();
    private readonly DbContext _dbContext = dbContext;

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}