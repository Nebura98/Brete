using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;

public interface IStaffRepository
{
    Task CreateAsync(StaffEntity staff);
    Task UpdateAsync(StaffEntity staff);
    Task DisableAsync(Guid staffId);
    Task DeleteAsync(Guid staffId);
    Task<StaffEntity> GetByIdAsync(Guid staffId);
    Task<List<StaffEntity>> ListAllAsync();
}
