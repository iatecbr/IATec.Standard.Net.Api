using System.Linq.Expressions;

namespace Domain.Contracts.Repositories.Generic;

public interface IGenericRepositoryQuery
{
    IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
}