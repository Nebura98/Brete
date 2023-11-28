﻿using Brete.Cmd.Api.Commands;
using Brete.Cmd.Domain.Aggregates.JobAggregate;
using Brete.Cmd.Infrastructure.Handlers;
using Brete.Cmd.Infrastructure.Producers;
using Brete.Cmd.Infrastructure.Repositories;
using Brete.Cmd.Infrastructure.Stores;
using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using CQRS.Core.Producers;

namespace Brete.Cmd.Api.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureService(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventProducer, EventProducer>();
        services.AddScoped<IEventStore, EventStore>();
        services.AddScoped<IEventSourcingHandler<JobAggregate>, EventSourcingHandler>();
        services.AddScoped<ICommandHandler, CommandHandler>();
        return services;
    }
}