using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobDeletedEvent : BaseEvent
{
    public JobDeletedEvent() : base(nameof(JobDeletedEvent)) { }
    public required bool IsDeleted { get; set; }
}