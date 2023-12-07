using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;

public interface IJobRepository
{
    Task CreateAsync(JobEntity job);
    Task UpdateAsync(JobEntity job);
    Task DisableAsync(JobEntity job);
    Task DeleteAsync(JobEntity job);
    Task RemoveAsync(JobEntity job);
    Task<JobEntity> GetByIdAsync(Guid jobId);
    Task<List<JobEntity>> ListAllAsync(Guid jobId);
}
