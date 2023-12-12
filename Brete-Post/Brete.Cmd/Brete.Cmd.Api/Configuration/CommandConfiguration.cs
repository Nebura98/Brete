using Brete.Cmd.Api.Commands;
using Brete.Cmd.Api.Commands.Company;
using Brete.Cmd.Api.Commands.Job;
using Brete.Cmd.Api.Commands.Skill;
using Brete.Cmd.Api.Commands.User;
using Brete.Cmd.Infrastructure.Dispatchers;
using CQRS.Core.Infrastructure;

namespace Brete.Cmd.Api.Configuration;

public static class CommandConfiguration
{
    public static WebApplicationBuilder ConfigureCommands(this WebApplicationBuilder builder)
    {
        ICommandHandler commandHandler = builder.Services.BuildServiceProvider().GetRequiredService<ICommandHandler>();

        CommandDispatcher dispatcher = new();

        dispatcher.RegisterHandler<CreateCompanyCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<UpdateCompanyCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DisableCompanyCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DeleteCompanyCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<CreateJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<UpdateJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DisableJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DeleteJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<RemoveJobCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<CreateSkillCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<UpdateSkillCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DisableSkillCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DeleteSkillCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<CreateUserCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<UpdateUserCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<UpdatePasswordUserCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DisableUserCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DeleteUserCommand>(commandHandler.HandleAsync);
        builder.Services.AddSingleton<ICommandDispatcher>(_ => dispatcher);

        return builder;
    }
}
