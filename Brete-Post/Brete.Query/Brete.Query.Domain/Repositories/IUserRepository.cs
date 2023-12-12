using Brete.Query.Domain.Entities;
using CQRS.Core.Infrastructure;

namespace Brete.Query.Domain.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{
}
