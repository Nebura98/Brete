using Brete.Query.Api.Queries.User;
using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;

namespace Brete.Query.Api.Queries;

public class QueryHandler : IQueryHandler
{
    private readonly IUserRepository _userRepository;

    public QueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserEntity?>> HandleAsync(FindAllUsersQuery query)
    {
        return await _userRepository.ListAllAsync();
    }
}
