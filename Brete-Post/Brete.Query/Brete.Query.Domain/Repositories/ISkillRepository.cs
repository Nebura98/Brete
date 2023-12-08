using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;
public interface ISkillRepository
{
    Task CreateAsync(SkillEntity skill);
    Task UpdateAsync(SkillEntity skill);
    Task DisableAsync(SkillEntity skill);
    Task DeleteAsync(SkillEntity skill);
    Task<SkillEntity> GetByIdAsync(Guid skillId);
    Task<List<SkillEntity>> ListAllAsync();
}

