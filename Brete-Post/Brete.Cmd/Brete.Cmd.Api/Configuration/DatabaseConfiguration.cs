using Brete.Cmd.Infrastructure.Config;
using Confluent.Kafka;

namespace Brete.Cmd.Api.Configuration;

public static class DatabaseConfiguration
{
    public static WebApplicationBuilder ConfigureMongoDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));
        return builder;
    }

    public static WebApplicationBuilder ConfigureKafka(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection(nameof(ProducerConfig)));
        return builder;
    }
}
