using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;
using CQRS.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Brete.Query.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository, ISQLRepository<CompanyEntity>
{
    private readonly DatabaseContextFactory _databaseContextFactory;

    public CompanyRepository(DatabaseContextFactory databaseContextFactory)
    {
        _databaseContextFactory = databaseContextFactory;
    }

    public async Task CreateAsync(CompanyEntity company)
    {
        using DatabaseContext context = _databaseContextFactory.CreateDbContext();
        context.Company.Add(company);

        _ = await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(CompanyEntity company)
    {
        using DatabaseContext context = _databaseContextFactory.CreateDbContext();
        context.Company.Update(company);

        _ = await context.SaveChangesAsync();
        throw new NotImplementedException();
    }

    public async Task DisableAsync(CompanyEntity company)
    {
        using DatabaseContext context = _databaseContextFactory.CreateDbContext();

        context.Company.Update(company);

        _ = await context.SaveChangesAsync();
    }

    public async Task<CompanyEntity?> GetByIdAsync(Guid id)
    {
        using DatabaseContext context = _databaseContextFactory.CreateDbContext();

        return await context.Company.
                            FirstOrDefaultAsync(company => company.Id == id);
    }


    public Task<bool> HasValueInDatabaseAsync(CompanyEntity value)
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

    public async Task UpdateAsync(CompanyEntity company)
    {
        using DatabaseContext context = _databaseContextFactory.CreateDbContext();

        context.Company.Update(company);

        _ = await context.SaveChangesAsync();
    }
}
