using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;

namespace Brete.Query.Infrastructure.Repositories;

public sealed class SkillRepository : ISkillRepository
{
    private readonly DatabaseContextFactory databaseContextFactory;

    public SkillRepository(DatabaseContextFactory databaseContextFactory)
    {
        this.databaseContextFactory = databaseContextFactory;
    }

    public Task CreateAsync(SkillEntity skill)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid skillId)
    {
        throw new NotImplementedException();
    }

    public Task DisableAsync(Guid skillId)
    {
        throw new NotImplementedException();
    }

    public Task<SkillEntity> GetByIdAsync(Guid skillId)
    {
        throw new NotImplementedException();
    }

    public Task<List<SkillEntity>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SkillEntity skill)
    {
        throw new NotImplementedException();
    }
}
