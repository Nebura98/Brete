namespace Brete.Query.Domain.Repositories;

public interface IJobRepository
{
    Task CreateAsync();
    Task UpdateAsync();
    Task DisableAsync(Guid jobId);
    Task DeleteAsync(Guid jobId);
    Task<Guid> GetByIdAsync(Guid jobId);
    Task<List<Guid>> ListByCompanyAsync(Guid jobId);
    Task<List<Guid>> ListByCriteria0Async(Guid jobId);
}
