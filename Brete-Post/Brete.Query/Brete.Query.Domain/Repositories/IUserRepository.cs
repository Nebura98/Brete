using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;

public interface IUserRepository
{
    Task CreateAsync(UserEntity user);
    Task UpdateAsync(UserEntity user);
    Task DisableAsync(Guid userId);
    Task DeleteAsync(Guid userId);
    Task<UserEntity> GetByIdAsync(Guid userId);
    Task<List<UserEntity>> ListAllAsync();
}
