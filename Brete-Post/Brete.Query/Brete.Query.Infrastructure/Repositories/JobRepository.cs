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

    public Task CreateAsync()
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

    public Task<Guid> GetByIdAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Guid>> ListByCompanyAsync(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Guid>> ListByCriteria0Async(Guid jobId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
}
