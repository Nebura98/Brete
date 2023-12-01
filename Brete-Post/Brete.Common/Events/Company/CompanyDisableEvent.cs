using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyDisableEvent : BaseEvent
{
    public CompanyDisableEvent() : base(nameof(CompanyDisableEvent))
    {
    }
    public bool IsActive { get; set; }

}
