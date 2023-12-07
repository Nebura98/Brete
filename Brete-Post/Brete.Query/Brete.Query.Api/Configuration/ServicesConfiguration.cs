using Brete.Query.Api.Queries;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.Consumers;
using Brete.Query.Infrastructure.Handlers;
using Brete.Query.Infrastructure.Repositories;
using Confluent.Kafka;
using CQRS.Core.Consumers;
using EventHandler = Brete.Query.Infrastructure.Handlers.EventHandler;

namespace Brete.Query.Api.Configuration;

public static class ServicesConfiguration
{
    public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IJobRepository, JobRepository>();
        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<IQueryHandler, QueryHandler>();
        builder.Services.AddScoped<IEventHandler, EventHandler>();
        builder.Services.Configure<ConsumerConfig>(builder.Configuration.GetSection(nameof(ConsumerConfig)));
        builder.Services.AddScoped<IEventConsumer, EventConsumer>();

        return builder;
    }
}
