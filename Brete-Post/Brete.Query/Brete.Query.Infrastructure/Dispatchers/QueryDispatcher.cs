using Brete.Query.Domain.Entities;
using CQRS.Core.Infrastructure;
using CQRS.Core.Queries;

namespace Brete.Query.Infrastructure.Dispatchers;

public class QueryDispatcher : IQueryDispatcher<UserEntity>
{
    private readonly Dictionary<Type, Func<BaseQuery, Task<List<UserEntity>>>> _handlers = new();

    public void RegisterHandler<TQuery>(Func<TQuery, Task<List<UserEntity>>> handler) where TQuery : BaseQuery
    {
        if (_handlers.ContainsKey(typeof(TQuery)))
        {
            throw new IndexOutOfRangeException("You cannot register the same query handler twice!");
        }

        _handlers.Add(typeof(TQuery), x => handler((TQuery)x));
    }

    public async Task<List<UserEntity>> SendAsync(BaseQuery query)
    {
        if (_handlers.TryGetValue(query.GetType(), out Func<BaseQuery, Task<List<UserEntity>>> handler))
        {
            return await handler(query);
        }

        throw new ArgumentNullException(nameof(handler), "No query handler was registered!");
    }
}
