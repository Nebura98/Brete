using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;
public interface ISkillRepository
{
    Task CreateAsync(SkillEntity skill);
    Task UpdateAsync(SkillEntity skill);
    Task DisableAsync(Guid skillId);
    Task DeleteAsync(Guid skillId);
    Task<SkillEntity> GetByIdAsync(Guid skillId);
    Task<List<SkillEntity>> ListAllAsync();
}

