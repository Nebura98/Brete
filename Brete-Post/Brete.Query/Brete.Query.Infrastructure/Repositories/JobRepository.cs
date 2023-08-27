﻿using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;

namespace Brete.Query.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly DatabaseContextFactory databaseContextFactory;

    public JobRepository(DatabaseContextFactory databaseContextFactory)
    {
        this.databaseContextFactory = databaseContextFactory;
    }

    public Task CreateAsync(JobEntity job)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task DisableAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<JobEntity> GetByIdAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<List<JobEntity>> ListAllAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<List<JobEntity>> ListByCriteriaAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(JobEntity job)
    {
        throw new NotImplementedException();
    }
}
