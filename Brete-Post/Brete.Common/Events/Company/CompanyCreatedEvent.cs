using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyCreatedEvent : BaseEvent
{
    public CompanyCreatedEvent() : base(nameof(CompanyCreatedEvent))
    {
    }
}
