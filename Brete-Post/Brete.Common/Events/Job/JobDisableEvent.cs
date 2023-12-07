using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobDisableEvent : BaseEvent
{
    public JobDisableEvent() : base(nameof(JobDisableEvent)) { }
    public required bool IsOpen { get; set; }
}
