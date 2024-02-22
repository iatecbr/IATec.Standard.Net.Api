using System.Linq.Expressions;
using Domain.Contracts.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Generic;

internal class GenericRepositoryQuery(ReadDataContext readDataContext) : IGenericRepositoryQuery
{
    public IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var query = readDataContext.Set<T>()
            .AsQueryable();
        
        query = includeProperties.Aggregate(query, (current, includeProperty) 
            => current.Include(includeProperty));

        return query;
    }
}