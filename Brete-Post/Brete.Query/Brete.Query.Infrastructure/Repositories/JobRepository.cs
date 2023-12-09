using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.Caching;
using Brete.Query.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Brete.Query.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly DatabaseContextFactory _contextFactory;
    private readonly CacheService _cacheService;

    public JobRepository(DatabaseContextFactory contextFactory, CacheService cacheService)
    {
        _contextFactory = contextFactory;
        _cacheService = cacheService;
    }

    public async Task CreateAsync(JobEntity job)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Job.Add(job);

        _ = await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(JobEntity job)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Job.Update(job);

        _ = await context.SaveChangesAsync();
    }

    public async Task DisableAsync(JobEntity job)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Job.Update(job);

        _ = await context.SaveChangesAsync();
    }

    public async Task<JobEntity> GetByIdAsync(Guid jobId)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        return await context.Job
                    .FirstOrDefaultAsync(job => job.Id == jobId);
    }

    public Task<List<JobEntity>> ListAllAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<List<JobEntity>> ListByCriteriaAsync(JobEntity job)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(JobEntity job)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Job.Remove(job);

        _ = await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(JobEntity job)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Job.Update(job);

        _ = await context.SaveChangesAsync();
    }
}
