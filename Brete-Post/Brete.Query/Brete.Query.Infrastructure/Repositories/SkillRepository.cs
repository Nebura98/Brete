using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;
using CQRS.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Brete.Query.Infrastructure.Repositories;

public sealed class SkillRepository : ISkillRepository, ISQLRepository<string>
{
    private readonly DatabaseContextFactory _contextFactory;

    public SkillRepository(DatabaseContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CreateAsync(SkillEntity skill)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();

        var doesExist = await HasValueInDatabaseAsync(skill.Name);

        if (doesExist)
        {
            Console.WriteLine("Content already exist");
            return;
        }

        _ = context.Skill.Add(skill);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(SkillEntity skill)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Update(skill);

        await context.SaveChangesAsync();
    }

    public async Task DisableAsync(SkillEntity skill)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Update(skill);

        await context.SaveChangesAsync();
    }

    public async Task<SkillEntity?> GetByIdAsync(Guid skillId)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        return await context.Skill
                            .FirstOrDefaultAsync(skill => skill.Id == skillId);

    }

    public async Task<bool> HasValueInDatabaseAsync(string name)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();

        return await context.Skill.AnyAsync(s => s.Name == name);
    }

    public Task<List<SkillEntity?>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(SkillEntity skill)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();
        context.Update(skill);

        await context.SaveChangesAsync();
    }
}
