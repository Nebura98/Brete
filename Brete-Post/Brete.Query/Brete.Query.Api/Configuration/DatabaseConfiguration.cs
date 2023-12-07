using Brete.Query.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Brete.Query.Api.Configuration;

public static class DatabaseConfiguration
{
    public static WebApplicationBuilder ConfigurePostgresSQLDatabase(this WebApplicationBuilder builder)
    {
        Action<DbContextOptionsBuilder> configureDbContext = options => options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQL"));
        builder.Services.AddDbContext<DatabaseContext>(configureDbContext);
        builder.Services.AddSingleton(new DatabaseContextFactory(configureDbContext));

        // create database and tables
        var dataContext = builder.Services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
        dataContext.Database.EnsureCreated();

        return builder;
    }
}
