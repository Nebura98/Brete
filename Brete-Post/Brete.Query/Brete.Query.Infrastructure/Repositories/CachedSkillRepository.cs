using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Brete.Query.Infrastructure.Repositories;

public class CachedSkillRepository : ISkillRepository
{
    private readonly ISkillRepository _decorated;
    private readonly IDistributedCache _distributedCache;
    public CachedSkillRepository(ISkillRepository decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
    }

    public Task CreateAsync(SkillEntity skill)
    {
        return _decorated.CreateAsync(skill);
    }

    public Task DeleteAsync(SkillEntity skill)
    {
        return _decorated.DeleteAsync(skill);
    }

    public Task DisableAsync(SkillEntity skill)
    {
        return _decorated.DisableAsync(skill);
    }

    public async Task<SkillEntity?> GetByIdAsync(Guid skillId)
    {
        string key = $"skill-{skillId}";

        string? cacheSkill = await _distributedCache.GetStringAsync(key);

        SkillEntity? skill;

        if (string.IsNullOrEmpty(cacheSkill))
        {
            skill = await _decorated.GetByIdAsync(skillId);

            if (skill is null) return skill;

            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(skill));

            return skill;
        }

        skill = JsonSerializer.Deserialize<SkillEntity>(cacheSkill);

        return skill;
    }

    public Task<List<SkillEntity>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SkillEntity skill)
    {
        return _decorated.UpdateAsync(skill);
    }
}
