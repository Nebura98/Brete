using Brete.Query.Api.Queries;
using Brete.Query.Api.Queries.User;
using Brete.Query.Domain.Entities;
using Brete.Query.Infrastructure.Dispatchers;
using CQRS.Core.Infrastructure;

namespace Brete.Query.Api.Configuration;

public static class QueryConfiguration
{
    public static WebApplicationBuilder ConfigureQuery(this WebApplicationBuilder builder)
    {
        var queryHandler = builder.Services.BuildServiceProvider().GetRequiredService<IQueryHandler>();
        var dispatcher = new QueryDispatcher();

        dispatcher.RegisterHandler<FindAllUsersQuery>(queryHandler.HandleAsync);
        builder.Services.AddScoped<IQueryDispatcher<UserEntity>>(_ => dispatcher);

        return builder;
    }
}

