using System.Linq.Expressions;

namespace Domain.Contracts.Repositories;

public interface IRepositoryQuery
{
    IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
}