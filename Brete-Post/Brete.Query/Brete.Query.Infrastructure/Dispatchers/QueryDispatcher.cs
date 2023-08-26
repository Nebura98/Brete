using Brete.Query.Domain.Entities;
using CQRS.Core.Infrastructure;
using CQRS.Core.Queries;

namespace Brete.Query.Infrastructure.Dispatchers;

public class QueryDispatcher : IQueryDispatcher<CompanyEntity>
{
    private readonly Dictionary<Type, Func<BaseQuery, Task<List<CompanyEntity>>>> _handlers = new();

    public void RegisterHandler<TQuery>(Func<TQuery, Task<List<CompanyEntity>>> handler) where TQuery : BaseQuery
    {
        if (_handlers.ContainsKey(typeof(TQuery)))
        {
            throw new IndexOutOfRangeException("You cannot register the same query handler twice!");
        }

        _handlers.Add(typeof(TQuery), x => handler((TQuery)x));
    }

    public async Task<List<CompanyEntity>> SendAsync(BaseQuery query)
    {
        if (_handlers.TryGetValue(query.GetType(), out Func<BaseQuery, Task<List<CompanyEntity>>> handler))
        {
            return await handler(query);
        }

        throw new ArgumentNullException(nameof(handler), "No query handler was registered!");
    }
}
