using Domain.Contracts.Entities;

namespace Domain.Contracts.Repositories.Generic;

public interface IReadRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);
}