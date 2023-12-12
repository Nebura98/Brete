using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

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

        string key = $"company-{company.Id}";

        await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(company));
    }

    public async Task DeleteAsync(CompanyEntity company)
    {
        await _decorated.DeleteAsync(company);

        string key = $"company-{company.Id}";

        await _distributedCache.RemoveAsync(key);
    }

    public async Task DisableAsync(CompanyEntity company)
    {
        await _decorated.DisableAsync(company);

        string key = $"company-{company.Id}";

        await _distributedCache.RemoveAsync(key);
    }

    public async Task<CompanyEntity?> GetByIdAsync(Guid id)
    {
        return await _decorated.GetByIdAsync(id);
    }

    public Task<List<CompanyEntity?>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<CompanyEntity>> SearchByCriteriaAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(CompanyEntity company)
    {
        await _decorated.UpdateAsync(company);

        string key = $"company-{company.Id}";

        await _distributedCache.RemoveAsync(key);

        await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(company));
    }
}
