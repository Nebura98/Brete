using Brete.Common.Events.Company;

namespace Brete.Query.Infrastructure.Handlers;

public interface IEventHandler
{
    Task On(CompanyCreatedEvent @event);
    Task On(CompanyDisableEvent @event);
    Task On(CompanyUpdatedEvent @event);
    Task On(CompanyDeletedEvent @event);
}
