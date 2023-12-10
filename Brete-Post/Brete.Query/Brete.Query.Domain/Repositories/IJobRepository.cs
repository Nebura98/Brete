using Brete.Query.Domain.Entities;
using CQRS.Core.Infrastructure;

namespace Brete.Query.Domain.Repositories;

public interface IJobRepository : IBaseRepository<JobEntity>
{
    Task RemoveAsync(JobEntity job);
    Task<List<JobEntity>> ListAllAsync(Guid jobId);
}
