using Brete.Cmd.Domain.Aggregates.JobAggregate;
using CQRS.Core.Handlers;

namespace Brete.Cmd.Api.Commands;

public class CommandHandler : ICommandHandler
{
    private readonly IEventSourcingHandler<JobAggregate> _eventSourcingHandler;

    public CommandHandler(IEventSourcingHandler<JobAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }
}
