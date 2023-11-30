using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyRemovedEvent : BaseEvent
{
    public CompanyRemovedEvent() : base(nameof(CompanyRemovedEvent))
    {
    }
}
