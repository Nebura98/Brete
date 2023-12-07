using Brete.Cmd.Api.Commands;
using Brete.Cmd.Api.Commands.Job;
using Brete.Cmd.Infrastructure.Dispatchers;
using CQRS.Core.Infrastructure;

namespace Brete.Cmd.Api.Configuration;

public static class CommandConfiguration
{
    public static WebApplicationBuilder ConfigureCommands(this WebApplicationBuilder builder)
    {
        ICommandHandler commandHandler = builder.Services.BuildServiceProvider().GetRequiredService<ICommandHandler>();

        CommandDispatcher dispatcher = new();

        //dispatcher.RegisterHandler<CreateCompanyCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<UpdateCompanyCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<DisableCompanyCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<RemoveCompanyCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<CreateJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<UpdateJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DisableJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DeleteJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<RemoveJobCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<CreateSkillCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<UpdateSkillCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<DisableSkillCommand>(commandHandler.HandleAsync);
        //dispatcher.RegisterHandler<RemoveSkillCommand>(commandHandler.HandleAsync);
        builder.Services.AddSingleton<ICommandDispatcher>(_ => dispatcher);

        return builder;
    }
}
