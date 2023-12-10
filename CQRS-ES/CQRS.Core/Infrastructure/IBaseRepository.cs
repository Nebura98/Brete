namespace CQRS.Core.Infrastructure;

public interface IBaseRepository<T>
{
    Task CreateAsync(T value);
    Task UpdateAsync(T value);
    Task DisableAsync(T value);
    Task DeleteAsync(T value);
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T?>> ListAllAsync();
}
