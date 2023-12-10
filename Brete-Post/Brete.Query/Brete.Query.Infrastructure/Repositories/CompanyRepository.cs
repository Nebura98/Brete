﻿using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;
using CQRS.Core.Infrastructure;

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

    public Task UpdateAsync(CompanyEntity value)
    {
        throw new NotImplementedException();
    }
}
