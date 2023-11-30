using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;

public interface IJobRepository
{
    Task CreateAsync(JobEntity job);
    Task UpdateAsync(JobEntity job);
    Task DisableAsync(Guid jobId);
    Task DeleteAsync(Guid jobId);
    Task<JobEntity> GetByIdAsync(Guid jobId);
    Task<List<JobEntity>> ListAllAsync(Guid jobId);
}
