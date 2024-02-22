namespace Domain.Contracts.Repositories.Generic;

public interface IReadRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);
}