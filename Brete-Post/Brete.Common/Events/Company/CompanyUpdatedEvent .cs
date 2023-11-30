using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyUpdatedEvent : BaseEvent
{
    public CompanyUpdatedEvent() : base(nameof(CompanyUpdatedEvent))
    {
    }
}
