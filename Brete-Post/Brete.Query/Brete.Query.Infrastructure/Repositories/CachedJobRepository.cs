using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Brete.Query.Infrastructure.Repositories;

public class CachedJobRepository : IJobRepository
{
    private readonly IJobRepository _decorated;
    private readonly IDistributedCache _distributedCache;

    public CachedJobRepository(IJobRepository decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
    }

    public Task CreateAsync(JobEntity value)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(JobEntity value)
    {
        throw new NotImplementedException();
    }

    public Task DisableAsync(JobEntity value)
    {
        throw new NotImplementedException();
    }

    public Task<JobEntity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<JobEntity>> ListAllAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<List<JobEntity?>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(JobEntity job)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(JobEntity value)
    {
        throw new NotImplementedException();
    }
}
