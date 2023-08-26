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

    public Task CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetByIdAsync(Guid companyId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Guid>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Guid>> SearchByCriteriaAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
}
