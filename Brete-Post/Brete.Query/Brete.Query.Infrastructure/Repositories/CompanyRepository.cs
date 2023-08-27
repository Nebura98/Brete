using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;

namespace Brete.Query.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly DatabaseContextFactory _databaseContextFactory;

    public CompanyRepository(DatabaseContextFactory databaseContextFactory)
    {
        _databaseContextFactory = databaseContextFactory;
    }

    public Task CreateAsync(CompanyEntity company)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid companyId)
    {
        throw new NotImplementedException();
    }

    public Task DisableAsync(Guid companyId)
    {
        throw new NotImplementedException();
    }

    public Task GetByIdAsync(Guid companyId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CompanyEntity>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<CompanyEntity>> SearchByCriteriaAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CompanyEntity company)
    {
        throw new NotImplementedException();
    }
}
