using Brete.Query.Api.Queries.User;
using Brete.Query.Domain.Entities;

namespace Brete.Query.Api.Queries;

public interface IQueryHandler
{
    Task<List<UserEntity?>> HandleAsync(FindAllUsersQuery query);
}
