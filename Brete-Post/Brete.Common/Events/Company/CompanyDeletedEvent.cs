using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyDeletedEvent : BaseEvent
{
    public CompanyDeletedEvent() : base(nameof(CompanyDeletedEvent))
    {
    }
    public bool IsActive { get; set; }

}
