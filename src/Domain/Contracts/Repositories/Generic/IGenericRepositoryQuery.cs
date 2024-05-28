using System.Linq.Expressions;
using Domain.Contracts.Entities;

namespace Domain.Contracts.Repositories.Generic;

public interface IGenericRepositoryQuery
{
    IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class, IEntity;
}