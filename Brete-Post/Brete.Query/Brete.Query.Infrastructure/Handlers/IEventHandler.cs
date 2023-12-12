using Brete.Common.Events.Company;
using Brete.Common.Events.User;

namespace Brete.Query.Infrastructure.Handlers;

public interface IEventHandler
{
    Task On(CompanyCreatedEvent @event);
    Task On(CompanyDisableEvent @event);
    Task On(CompanyUpdatedEvent @event);
    Task On(CompanyDeletedEvent @event);
    Task On(UserCreatedEvent @event);
}
