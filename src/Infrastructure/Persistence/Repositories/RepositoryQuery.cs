using System.Linq.Expressions;
using Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RepositoryQuery(DataContext dataContext) : IRepositoryQuery
{
    public IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var query = dataContext.Set<T>()
            .AsQueryable()
            .AsNoTrackingWithIdentityResolution();
        
        query = includeProperties.Aggregate(query, (current, includeProperty) 
            => current.Include(includeProperty));

        return query;
    }
}