using Brete.Query.Api.Queries;
using Brete.Query.Infrastructure.Dispatchers;

namespace Brete.Query.Api.Configuration;

public static class QueryConfiguration
{
    public static WebApplicationBuilder ConfigureQuery(this WebApplicationBuilder builder)
    {
        var queryHandler = builder.Services.BuildServiceProvider().GetRequiredService<IQueryHandler>();
        var dispatcher = new QueryDispatcher();

        return builder;
    }
}

