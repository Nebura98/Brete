namespace CQRS.Core.Infrastructure;

public interface ISQLRepository<T>
{
    Task<bool> HasValueInDatabaseAsync(T value);
}
