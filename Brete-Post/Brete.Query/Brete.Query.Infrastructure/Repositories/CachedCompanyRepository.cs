using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Brete.Query.Infrastructure.Repositories;

public class CachedCompanyRepository : ICompanyRepository
{
    private readonly ICompanyRepository _decorated;
    private readonly IDistributedCache _distributedCache;

    public CachedCompanyRepository(ICompanyRepository decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
    }

    public async Task CreateAsync(CompanyEntity company)
    {
        await _decorated.CreateAsync(company);
    }

    public Task DeleteAsync(CompanyEntity value)
    {
        throw new NotImplementedException();
    }

    public Task DisableAsync(CompanyEntity value)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyEntity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CompanyEntity?>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<CompanyEntity>> SearchByCriteriaAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CompanyEntity value)
    {
        throw new NotImplementedException();
    }
}
